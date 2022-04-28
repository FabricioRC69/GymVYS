using GymVidaYSaludWEB.Entities;
using GymVidaYSaludWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using static GymVidaYSaludWEB.Entities.DatosCliente;

namespace GymVidaYSaludWEB.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [FiltroDeSesion]
        public IActionResult Index()
        {
            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AcercaNosotros()
        {
            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            return View();
        }
        public IActionResult Contacto()
        {
            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            return View();
        }
        public IActionResult Membresias()
        {
            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}