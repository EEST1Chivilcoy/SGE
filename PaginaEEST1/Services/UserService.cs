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
                var userName = user.FindFirst(ClaimTypes.Name)?.Value;
                var userSurname = user.FindFirst(ClaimTypes.Surname)?.Value;
                TypeGender userGender;
                var userBirthDate = Convert.ToDateTime(user.FindFirst(ClaimTypes.DateOfBirth)?.Value);
                var userAddress = user.FindFirst(ClaimTypes.StreetAddress)?.Value;

                // Genero Logica

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
                    var isProfesor = user.HasClaim(c => c.Type == "groups" && c.Value == "ProfesorGroupId");
                    var isEMATP = user.HasClaim(c => c.Type == "groups" && c.Value == "EMATPGroupId");

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
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
