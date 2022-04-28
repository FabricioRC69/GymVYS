using GymVidaYSaludWEB.Entities;
using GymVidaYSaludWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static GymVidaYSaludWEB.Entities.DatosCliente;

namespace GymVidaYSaludWEB.Controllers
{
    [FiltroDeSesion]
    public class DatosClientesController : Controller
    {

        ClientesModel modelo = new ClientesModel();
        private readonly IConfiguration _configuration;
        HttpClientHandler _clientHandler = new HttpClientHandler();

        DatosCliente cliente = new DatosCliente();
        List<DatosCliente> clientes = new List<DatosCliente>();

        public DatosClientesController(IConfiguration configuration)
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult ConsultarTodosClientes() {
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarTodosClientes";
            var resultado = modelo.ConsultarTodosClientes(ruta);

            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            var mensaje = HttpContext.Session.GetString("client-created-message");
            if(mensaje == null)
            {

                ViewBag.Mensage = "";
            } else
            {

                ViewBag.Mensage = mensaje;
            }

            return View(resultado);
        }



        [HttpGet]
        public IActionResult ConsultarUnCliente(long idCliente)
        {

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnCliente?idCliente=" + idCliente;
            var resultado = modelo.ConsultarUnCliente(ruta);

            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;

            return View(resultado);
        }


        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            var objeto = new DatosCliente();
            HttpContext.Session.SetString("Estado", "registrando");
            return View(objeto);
        }

        [HttpPost]
        public IActionResult RegistrarCliente(DatosCliente cliente) {
            if (!ModelState.IsValid)
            {
                var usuario = HttpContext.Session.GetString("NombreUsuario");
                ViewBag.Usuario = usuario;
                var correo = HttpContext.Session.GetString("Correo");
                ViewBag.Correo = correo;
                var rol = HttpContext.Session.GetString("Rol");
                ViewBag.Rol = rol;
                return View(cliente);
            }
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/RegistrarCliente";

            string mensaje = modelo.RegistrarCliente(ruta, cliente);
            if (mensaje == "Registro exitoso")
            {
                HttpContext.Session.SetString("client-created-message", "El cliente, cedula:" + cliente.Cedula + " y de nombre: " + cliente.NombreCompleto + "ha sido registro exitosamente");

                return RedirectToAction("ConsultarTodosClientes", "DatosClientes");
            }
            else {
                HttpContext.Session.SetString("error", "Error");
                return View(cliente);
            }
        }
        [HttpGet]
        public IActionResult ActualizarCliente(long idcliente)
        {
            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnCliente?idCliente=" + idcliente;
            var resultado = modelo.ConsultarUnCliente(ruta);

            return View(resultado);

        }

        [HttpPost]
        public IActionResult ActualizarCliente(DatosCliente cliente)
        {
            if (!ModelState.IsValid)
            {
                var usuario = HttpContext.Session.GetString("NombreUsuario");
                ViewBag.Usuario = usuario;
                var correo = HttpContext.Session.GetString("Correo");
                ViewBag.Correo = correo;
                var rol = HttpContext.Session.GetString("Rol");
                ViewBag.Rol = rol;
                string ruta2 = _configuration.GetSection("Llaves:RutaServicio").Value;
                ruta2 += "/api/Proyecto/ConsultarUnCliente?idCliente=" + cliente.idCliente;
                var resultado = modelo.ConsultarUnCliente(ruta2);
                return View(resultado);
            }

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ModificarCliente";

            string mensaje = modelo.ActualizarCliente(ruta, cliente);
            if (mensaje == "Actualización exitosa")
            {

                return RedirectToAction("ConsultarTodosClientes", "DatosClientes");
            }
            else
            {

                return View(cliente);
            }
        }
        [HttpGet]
        public IActionResult EliminarCliente(long idCliente) {

            string respuesta = "";
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/EliminarCliente?idCliente=" + idCliente;
            respuesta = modelo.EliminarCliente(ruta);
            return RedirectToAction("ConsultarTodosClientes", "DatosClientes");

            /*if (respuesta != null)
            {
                return RedirectToAction("ConsultarTodosClientes", "DatosClientes");
            }
            else {

                return RedirectToAction("RegistrarCliente", "DatosClientes"); ;    
            }*/
        }


        public IActionResult Index()
        {

            return View();
        }

    }
}
