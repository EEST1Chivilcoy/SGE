using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

//Servicios Utilizados
using PaginaEEST1.Services;

namespace PaginaEEST1.Components
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        // Inyección de dependencia del servicio en el constructor del controlador
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            var result = Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, OpenIdConnectDefaults.AuthenticationScheme);

            // Extraer información del usuario autenticado
            var user = User.Identity as ClaimsIdentity;

            if (user != null && user.IsAuthenticated)
            {
                
                var userEmail = user.FindFirst(ClaimTypes.Email)?.Value; // Correo electrónico del usuario
                
                var userName = user.FindFirst(ClaimTypes.Name)?.Value; // Nombre del usuario
                var userSurname = user.FindFirst(ClaimTypes.Surname)?.Value; // Apellido de Usuario
                var userGender = user.FindFirst(ClaimTypes.Gender)?.Value; // Genero del usuario
                var userDateOfBirth = user.FindFirst(ClaimTypes.DateOfBirth)?.Value; //Fecha de nacimiento del usuario

                // Foto del Usuario (Pendiente)

                // Rol del Usuario (Trabajar)
                var userRole = user.FindFirst(ClaimTypes.Role)?.Value;

                _userService.SynchronizeUser(user);
            }

            return result;
        }

        [HttpGet]
        public IActionResult Logout(string returnUrl = "/")
        {
            return SignOut(new AuthenticationProperties { RedirectUri = returnUrl },
                OpenIdConnectDefaults.AuthenticationScheme,
                "Cookies");
        }
    }
}