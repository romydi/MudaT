using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using MudarT.Datos;
using MudarT.Extensions;
using MudarT.Models;

namespace MudarT.Controllers
{
    public class LoginController : Controller
    {
        UsuarioDatos usuarioDatos = new UsuarioDatos();

        public IActionResult Login()
        {
            return View();
        }
		public IActionResult Registrarse()
		{
			return View();
		}


		[HttpPost]
        public IActionResult Acceso(string email, string contraseña)
        {
            var res = usuarioDatos.Login(email, contraseña);
            if(res > 0)
            {
                HttpContext.Session.SetObject("Usuario", res);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "usuario o contraseña incorrectos";
                return View();
            }

        }

        [HttpPost]
        public IActionResult Registro(ModelUsuario usuario)
        {
            var res = usuarioDatos.Guardar(usuario);
            if (res)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                ViewData["Mensaje"] = "usuario o contraseña incorrectos";
                return View();
            }
        }
    }
}
