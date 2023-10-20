using Microsoft.AspNetCore.Mvc;
using LibraryASP.Models;
using LibraryASP.Services.Contract;
using LibraryASP.Models.Resources;

using System.Security.Claims;//SEGURIDAD POR COOKIES
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
//SEGURIDAD POR COOKIES


namespace LibraryASP.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUserService _userService;
        public InicioController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult checkIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> checkIn(Usuario modelo)
        {
            modelo.Passwd = Utilities.EncryptPass(modelo.Passwd);
            Usuario usuario_creado = await _userService.SaveUsuario(modelo);

            if (usuario_creado.UsuarioId > 0)
                return RedirectToAction("logIn","Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }
        public IActionResult logIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> logIn(string correo, string pass)
        {
            Usuario usuario_encontrado = await _userService.GetUsuario(correo, Utilities.EncryptPass(pass));
            if(usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,usuario_encontrado.Nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties authenticationProperties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),authenticationProperties);

            return RedirectToAction("Index", "Home");
        }
    }
}
