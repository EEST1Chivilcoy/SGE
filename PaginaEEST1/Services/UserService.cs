using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaginaEEST1.Data;
using PaginaEEST1.Data.Enums;
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

                var userBirthDateClaim = user.FindFirst(ClaimTypes.DateOfBirth)?.Value;
                var userAddress = user.FindFirst(ClaimTypes.StreetAddress)?.Value;

                /*foreach (var claim in user.Claims)
                {
                    Console.WriteLine($"Type: {claim.Type}, Value: {claim.Value}");
                } <-- Para probar los datos obtenidos del Usuario*/

                // Validar valores obtenidos

                if (string.IsNullOrEmpty(personIdClaim) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userSurname))
                {
                    Console.WriteLine("Información insuficiente del usuario.");
                    if (string.IsNullOrEmpty(personIdClaim))
                    {
                        Console.WriteLine("Id nula");
                    }
                    else if (string.IsNullOrEmpty(userName))
                    {
                        Console.WriteLine("Nombre nulo");
                    }
                    else if (string.IsNullOrEmpty(userSurname)) 
                    {
                        Console.WriteLine("Apellido nulo");
                    }
                    return;
                }

                // Convertir fecha de nacimiento si existe
                DateTime? userBirthDate = null;
                if (!string.IsNullOrEmpty(userBirthDateClaim))
                {
                    userBirthDate = DateTime.TryParse(userBirthDateClaim, out DateTime parsedDate) ? parsedDate : (DateTime?)null;
                }

                // Determinar el género
                TypeGender userGender = user.FindFirst(ClaimTypes.Gender)?.Value switch
                {
                    "Male" => TypeGender.Male,
                    "Female" => TypeGender.Female,
                    _ => TypeGender.Other
                };

                // Verificar si el usuario ya existe en la base de datos
                var userExisting = await _context.People.SingleOrDefaultAsync(p => p.PersonId == personIdClaim);

                if (userExisting == null)
                {
                    // Determinar roles
                    var isProfesor = user.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "Profesor");
                    var isEMATP = user.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "EMATP");

                    // Crear la entidad correcta
                    if (isProfesor)
                    {
                        var newProfessor = new Professor
                        {
                            PersonId = personIdClaim,
                            Name = userName,
                            Surname = userSurname,
                            BirthDate = userBirthDate,
                            Address = userAddress,
                            Gender = userGender
                        };

                        _context.People.Add(newProfessor);
                    }

                    if (isEMATP)
                    {
                        var newEMATP = new EMATP
                        {
                            PersonId = personIdClaim,
                            Name = userName,
                            Surname = userSurname,
                            BirthDate = userBirthDate,
                            Address = userAddress,
                            Gender = userGender
                        };

                        _context.People.Add(newEMATP);
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
                }
            }
            else
            {
                Console.WriteLine("No se encontró el ID del usuario en los claims.");
            }
        }
    }
}
