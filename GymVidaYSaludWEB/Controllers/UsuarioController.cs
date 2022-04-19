using GymVidaYSaludWEB.Entities;
using GymVidaYSaludWEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static GymVidaYSaludWEB.Entities.DatosCliente;
using static GymVidaYSaludWEB.Entities.UsuariosObj;

namespace GymVidaYSaludWEB.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel modelo = new UsuarioModel();
        HttpClientHandler _clientHandler = new HttpClientHandler();
        private readonly IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConsultarUsuarioLogin(string Correo, string Contraseña)
        {

            using (var http = new HttpClient())
            {
                string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
                ruta += "/api/Proyecto/ConsultarLogin?Correo=" + Correo + "&Contraseña=" + Contraseña;
                var resultado = modelo.ConsultarUsuarioLogin(ruta);


                if (resultado != null)
                {
                    HttpContext.Session.SetString("Correo", Correo);
                    ViewBag.Correo = Correo;
                    return RedirectToAction("Index", "Home");

                }
                else 
                {
                    return RedirectToAction("LogIn", "Usuario");
                }
            }
        }

        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            var objeto = new UsuariosObj();
            return View(objeto);
        }

        [HttpPost]
        public IActionResult RegistraUsuario(UsuariosObj usuario)
        {
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/RegistrarUsuario";

            string mensaje = modelo.RegistraUsuario(ruta, usuario);
            if (mensaje == "Registro exitoso")
            {
                return RedirectToAction("LogIn", "Usuario");
            }
            else
            {
                return View(usuario);
            }
        }
        public IActionResult CerrarSesion()
        {
                HttpContext.Session.Clear();
                return RedirectToAction("LogIn", "Usuario");
        }

    }
}

