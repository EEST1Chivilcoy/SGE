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
                        Email = userEmail,
                        EntraIDRole = userRole
                    };

                    switch (userRole)
                    {
                        case "Profesor":
                            var newProfessor = new Professor
                            {
                                PersonId = newEmployee.PersonId,
                                Name = newEmployee.Name,
                                Surname = newEmployee.Surname,
                                Gender = newEmployee.Gender,
                                Email = newEmployee.Email,
                                EntraIDRole = newEmployee.EntraIDRole
                            };
                            _context.People.Add(newProfessor);
                            break;
                        case "EMATP":
                            var newEMATP = new EMATP
                            {
                                PersonId = newEmployee.PersonId,
                                Name = newEmployee.Name,
                                Surname = newEmployee.Surname,
                                Gender = newEmployee.Gender,
                                Email = newEmployee.Email,
                                EntraIDRole = newEmployee.EntraIDRole
                            };
                            _context.People.Add(newEMATP);
                            break;
                        case "Directivo":
                            var newSchoolPrincipal = new SchoolPrincipal
                            {
                                PersonId = newEmployee.PersonId,
                                Name = newEmployee.Name,
                                Surname = newEmployee.Surname,
                                Gender = newEmployee.Gender,
                                Email = newEmployee.Email,
                                EntraIDRole = newEmployee.EntraIDRole
                            };
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
                            Console.WriteLine("Usuario guardado correctamente.");
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

                    // Actualizar campos del usuario existente
                    userExisting.Name = userName;
                    userExisting.Surname = userSurname;
                    userExisting.Email = userEmail;

                    // Manejar la posible actualización del rol
                    if (userExisting.EntraIDRole != userRole)
                    {
                        Console.WriteLine("Actualización del Rol del usuario ya existe en la base de datos.");

                        // Eliminar el usuario existente
                        _context.People.Remove(userExisting);

                        // Crear nuevamente el usuario con el nuevo rol
                        var updateEmployee = new SchoolEmployee
                        {
                            PersonId = personIdClaim,
                            Name = userName,
                            Surname = userSurname,
                            Gender = TypeGender.Other,
                            Email = userEmail,
                            EntraIDRole = userRole
                        };

                        switch (userRole)
                        {
                            case "Profesor":
                                var newProfessor = new Professor
                                {
                                    PersonId = updateEmployee.PersonId,
                                    Name = updateEmployee.Name,
                                    Surname = updateEmployee.Surname,
                                    Gender = updateEmployee.Gender,
                                    Email = updateEmployee.Email,
                                    EntraIDRole = updateEmployee.EntraIDRole
                                };
                                _context.People.Add(newProfessor);
                                break;
                            case "EMATP":
                                var newEMATP = new EMATP
                                {
                                    PersonId = updateEmployee.PersonId,
                                    Name = updateEmployee.Name,
                                    Surname = updateEmployee.Surname,
                                    Gender = updateEmployee.Gender,
                                    Email = updateEmployee.Email,
                                    EntraIDRole = updateEmployee.EntraIDRole
                                };
                                _context.People.Add(newEMATP);
                                break;
                            case "Directivo":
                                var newSchoolPrincipal = new SchoolPrincipal
                                {
                                    PersonId = updateEmployee.PersonId,
                                    Name = updateEmployee.Name,
                                    Surname = updateEmployee.Surname,
                                    Gender = updateEmployee.Gender,
                                    Email = updateEmployee.Email,
                                    EntraIDRole = updateEmployee.EntraIDRole
                                };
                                _context.People.Add(newSchoolPrincipal);
                                break;
                            default:
                                Console.WriteLine("Rol de usuario no reconocido.");
                                break;
                        }

                        try
                        {
                            await _context.SaveChangesAsync();
                            Console.WriteLine("Usuario actualizado correctamente.");
                        }
                        catch (DbUpdateException dbEx)
                        {
                            Console.WriteLine($"Error al actualizar los cambios en la base de datos: {dbEx.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error inesperado: {ex.Message}");
                        }
                    }
                }
            }
            else
                Console.WriteLine("No se encontró el ID del usuario en los claims.");
        }
    }
}

