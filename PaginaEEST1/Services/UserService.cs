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
                //Datos de Persona
                var personIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userName = user.FindFirst(ClaimTypes.Name)?.Value;
                var userSurname = user.FindFirst(ClaimTypes.Surname)?.Value;
                TypeGender userGender;
                var userBirthDate = Convert.ToDateTime(user.FindFirst(ClaimTypes.DateOfBirth)?.Value);
                var userAddress = user.FindFirst(ClaimTypes.StreetAddress)?.Value;

                //Logica de Genero 

                switch (user.FindFirst(ClaimTypes.Gender)?.Value)
                {
                    case "Male": // Genero Masculino
                        userGender = TypeGender.Male;
                        break;
                    case "Female": // Genero Femenino 
                        userGender = TypeGender.Female;
                        break;
                    default: // Otro Genero
                        userGender = TypeGender.Other;
                        break;
                }

                // Verificar si el usuario ya existe en la base de datos
                var userExisting = _context.People.SingleOrDefault(p => p.PersonId == personIdClaim);

                if (userExisting == null)
                {
                    // Determinar si es Profesor en base a los grupos de seguridad
                    var isProfesor = user.HasClaim(c => c.Type == "groups" && c.Value == "32245a37-5f0b-4997-afbd-931120666c46");
                    var isEMATP = user.HasClaim(c => c.Type == "groups" && c.Value == "0f63c71b-ff32-4f4f-b925-cec681eadfa6");

                    if (isProfesor)
                    {
                        // Crear un nuevo Profesor
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

                    // Guardar los cambios de forma asíncrona
                    try
                    {
                        await _context.SaveChangesAsync();
                        Console.WriteLine("Usuario sincronizado correctamente.");
                    }
                    catch (Exception ex)
                    {
                        // Manejar la excepción
                        Console.WriteLine($"Error al guardar los cambios: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("El usuario ya existe en la base de datos.");
            }
        }
    }
}
