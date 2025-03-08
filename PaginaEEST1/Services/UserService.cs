using AntDesign;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
using PaginaEEST1.Data.Models.People;
using PaginaEEST1.Data.Models.Personal;
using System.Data;
using System.Security.Claims;

namespace PaginaEEST1.Services
{
    public interface IUserService
    {
        Task SynchronizeUser(ClaimsIdentity user);
    }

    public class UserService : IUserService
    {
        private readonly PaginaDbContext _context;
        public UserService(PaginaDbContext context)
        {
            _context = context;
        }

        public async Task SynchronizeUser(ClaimsIdentity user)
        {
            if (user == null || !user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                Console.WriteLine("No se encontró el ID del usuario en los claims.");
                return;
            }

            // Obtener datos del usuario
            var personIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = user.FindFirst(ClaimTypes.GivenName)?.Value;
            var userSurname = user.FindFirst(ClaimTypes.Surname)?.Value;
            var userEmail = user.FindFirst(ClaimTypes.Email)?.Value;
            var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(personIdClaim) || string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(userSurname) || string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userRole))
            {
                Console.WriteLine("Información insuficiente del usuario.");
                return;
            }

            var existingUser = await _context.People.SingleOrDefaultAsync(p => p.PersonId == personIdClaim);

            if (existingUser == null)
            {
                // Crear nuevo usuario
                await CreateUser(personIdClaim, userName, userSurname, userEmail, userRole);
            }
            else
            {
                // Actualizar usuario si es necesario
                bool needsUpdate = existingUser.Name != userName ||
                                   existingUser.Surname != userSurname ||
                                   existingUser.Email != userEmail ||
                                   existingUser.EntraIDRole != userRole;

                if (needsUpdate)
                {
                    await UpdateUser(existingUser, userName, userSurname, userEmail, userRole);
                }
                else
                {
                    Console.WriteLine("No se requieren actualizaciones para el usuario.");
                }
            }
        }

        private async Task CreateUser(string personId, string name, string surname, string email, string role)
        {
            var newUser = CreateUserInstance(personId, name, surname, email, role);
            if (newUser == null)
            {
                Console.WriteLine("Rol de usuario no reconocido.");
                return;
            }

            _context.People.Add(newUser);
            await SaveChangesWithTransaction();
        }

        private async Task UpdateUser(Person existingUser, string name, string surname, string email, string role)
        {
            // Si el rol cambia, debemos actualizar el tipo de usuario
            if (existingUser.EntraIDRole != role)
            {
                _context.People.Remove(existingUser);
                var updatedUser = CreateUserInstance(existingUser.PersonId, name, surname, email, role);
                if (updatedUser == null)
                {
                    Console.WriteLine("Rol de usuario no reconocido.");
                    return;
                }
                _context.People.Add(updatedUser);
            }
            else
            {
                // Solo actualizar datos personales si el rol no cambia
                existingUser.Name = name;
                existingUser.Surname = surname;
                existingUser.Email = email;
            }

            await SaveChangesWithTransaction();
        }

        private Person? CreateUserInstance(string personId, string name, string surname, string email, string role)
        {
            return role switch
            {
                "Profesor" => new Professor { PersonId = personId, Name = name, Surname = surname, Gender = TypeGender.Other, Email = email, EntraIDRole = role },
                "EMATP" => new EMATP { PersonId = personId, Name = name, Surname = surname, Gender = TypeGender.Other, Email = email, EntraIDRole = role },
                "Directivo" => new SchoolPrincipal { PersonId = personId, Name = name, Surname = surname, Gender = TypeGender.Other, Email = email, EntraIDRole = role },
                "Preceptor" => new Preceptor { PersonId = personId, Name = name, Surname = surname, Gender = TypeGender.Other, Email = email, EntraIDRole = role },
                "Panol" => new Storeroom { PersonId = personId, Name = name, Surname = surname, Gender = TypeGender.Other, Email = email, EntraIDRole = role },
                "Secretario" => new Secretary { PersonId = personId, Name = name, Surname = surname, Gender = TypeGender.Other, Email = email, EntraIDRole = role },
                _ => null
            };
        }

        private async Task SaveChangesWithTransaction()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                Console.WriteLine("Operación completada exitosamente.");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error al guardar cambios: {ex.Message}");
            }
        }
    }
}