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
            if (user != null && user.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))
            {
                // Datos de Persona
                var personIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userName = user.FindFirst(ClaimTypes.GivenName)?.Value;
                var userSurname = user.FindFirst(ClaimTypes.Surname)?.Value;
                var userEmail = user.FindFirst(ClaimTypes.Email)?.Value;
                var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

                // Validar valores obtenidos
                if (string.IsNullOrEmpty(personIdClaim) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userSurname) || string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userRole))
                {
                    Console.WriteLine("Información insuficiente del usuario.");
                    return;
                }

                // Verificar si el usuario ya existe en la base de datos
                var userExisting = await _context.People.SingleOrDefaultAsync(p => p.PersonId == personIdClaim);

                if (userExisting == null)
                {
                    var newEmployee = new SchoolEmployee
                    {
                        PersonId = personIdClaim,
                        Name = userName,
                        Surname = userSurname,
                        Gender = TypeGender.Other,
                        Email = userEmail
                    };

                    switch (userRole)
                    {
                        case "Profesor":
                            if (newEmployee is Professor newProfessor)
                                _context.People.Add(newProfessor);
                            break;
                        case "EMATP":
                            if (newEmployee is EMATP newEMATP) 
                                _context.People.Add(newEMATP);
                            break;
                        case "Directivo":
                            if (newEmployee is SchoolPrincipal newSchoolPrincipal)
                                _context.People.Add(newSchoolPrincipal);
                            break;
                        default:
                            Console.WriteLine("Rol de usuario no reconocido.");
                            break;
                    }

                    // Guardar los cambios en una transacción
                    using (var transaction = await _context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            await _context.SaveChangesAsync();
                            await transaction.CommitAsync();
                            Console.WriteLine("Usuario sincronizado correctamente.");
                        }
                        catch (DbUpdateException dbEx)
                        {
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Error al guardar los cambios en la base de datos: {dbEx.Message}");
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Error inesperado: {ex.Message}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El usuario ya existe en la base de datos.");
                    // Implementar Sincronización (Esto para cuando se actualize desde Entra ID)
                }
            }
            else
            {
                Console.WriteLine("No se encontró el ID del usuario en los claims.");
            }
        }
    }
}
