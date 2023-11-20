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
			var ingresoFallido = false;
			return View(ingresoFallido);
        }
		public IActionResult Registrarse()
		{
			var ingresoFallido = false;
			return View(ingresoFallido);
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
                var ingresoFallido = true;
                return View("Login", ingresoFallido);
            }
        }

        [HttpPost]
        public IActionResult Registro(ModelUsuario usuario)
        {
            if (usuario.email.Contains('@') && usuario.email.Contains('.') && usuario.contraseña.Length>=4 && usuario.nombre.Length>=2 && usuario.apellido.Length >= 2 && usuario.direccion.Length >= 2)
            {
				var res = usuarioDatos.Guardar(usuario);
				if (res)
				{
					return RedirectToAction("Login", "Login");
				}
				else
				{
					var ingresoFallido = true;
					return View("Registrarse", ingresoFallido);
				}
            }
            else
            {
				var ingresoFallido = true;
				return View("Registrarse", ingresoFallido);
			}
            
            
        }
    }
}
