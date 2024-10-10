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

            var user = User.Identity as ClaimsIdentity;

            if (user != null && user.IsAuthenticated)
            {
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