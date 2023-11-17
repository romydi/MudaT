using Microsoft.AspNetCore.Mvc;
using MudarT.Extensions;
using MudarT.Models;
using System.Diagnostics;
using MudarT.Permisos;
using MudarT.Datos;
using System.Text.Json.Nodes;

namespace MudarT.Controllers
{

    [ValidarSesion]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UsuarioDatos usuarioDatos = new UsuarioDatos();
        private VehiculoDatos vehiculoDatos = new VehiculoDatos();
        private ExtrasDatos extrasDatos = new ExtrasDatos();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int id = HttpContext.Session.GetObject<int>("Usuario");
            ModelUsuario user = usuarioDatos.Obtener(id);
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CerrarSesion()
		{
            HttpContext.Session.SetObject("Usuario", 0);
            return RedirectToAction("Login", "Login");
		}

        [HttpPost]
        public IActionResult LoginRedirect()
        {
            HttpContext.Session.SetObject("Usuario", 0);
            return RedirectToAction("Login", "Login");
        }

        public JsonResult TiposVehiculos()
        {
            var res = vehiculoDatos.Listar();


            var jsonString = Json(
                res
                );

            return jsonString;
        }
        public JsonResult TiposExtras()
        {
            var res = extrasDatos.Listar();


            var jsonString = Json(
                res
                );

            return jsonString;
        }
    }
}