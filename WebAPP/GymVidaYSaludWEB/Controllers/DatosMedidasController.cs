using GymVidaYSaludWEB.Entities;
using GymVidaYSaludWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymVidaYSaludWEB.Controllers
{
    [FiltroDeSesion]
    public class DatosMedidasController : Controller
    {
        MedidasModel modelo = new MedidasModel();
        private readonly IConfiguration _configuration;
        HttpClientHandler _clientHandler = new HttpClientHandler();

        DatosMedidas medida = new DatosMedidas();
        List<DatosMedidas> medidas = new List<DatosMedidas>();

        public DatosMedidasController(IConfiguration configuration)
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult ConsultarMedidas()
        {
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarTodasMedidas";
            var resultado = modelo.ConsultarMedidas(ruta);

            string ruta2 = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta2 += "/api/Proyecto/ConsultarTodosClientes";
            var resultado2 = modelo.ConsultarTodosClientesMedidas(ruta2);
            ViewBag.clientesMedidas = resultado2;

            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;

            return View(resultado);
        }


        [HttpGet]
        public IActionResult ConsultarUnaMedida(long idMedidas)
        {

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnaMedida?idMedidas=" + idMedidas;
            var resultado = modelo.ConsultarUnaMedida(ruta);

            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;

            return View(resultado);

        }

        [HttpGet]
        public IActionResult RegistrarMedida()
        {
            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/MedidaSelectList";
            var resultado = modelo.ConsultarMedidaSelectList(ruta);

            ViewBag.Lista = resultado;
            return View(new DatosMedidas());

        }

        [HttpPost]
        public IActionResult RegistrarMedida(DatosMedidas medida)
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
                ruta2 += "/api/Proyecto/MedidaSelectList";
                var resultado = modelo.ConsultarMedidaSelectList(ruta2);

                ViewBag.Lista = resultado;
                return View(medida);
            }
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/RegistrarMedida";

            string mensaje = modelo.RegistrarMedida(ruta, medida);
            if (mensaje == "Registro exitoso")
            {

                return RedirectToAction("ConsultarMedidas", "DatosMedidas");
            }
            else
            {

                return View(medida);
            }
        }


        [HttpGet]
        public IActionResult ActualizarMedida(long idmedidas, long idcliente)
        {

            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnaMedida?idMedidas=" + idmedidas;
            var resultado = modelo.ConsultarUnaMedida(ruta);
            string ruta1 = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta1 += "/api/Proyecto/MedidaSelectListAll?idCliente="+ idcliente;
            var resultado1 = modelo.ConsultarMedidaSelectList(ruta1);
            ViewBag.Lista = resultado1;
            return View(resultado);

        }

        [HttpPost]
        public IActionResult ActualizarMedida(DatosMedidas medida)
        {

            if (!ModelState.IsValid)
            {
                var usuario = HttpContext.Session.GetString("NombreUsuario");
                ViewBag.Usuario = usuario;
                var correo = HttpContext.Session.GetString("Correo");
                ViewBag.Correo = correo;
                var rol = HttpContext.Session.GetString("Rol");
                ViewBag.Rol = rol;

                string ruta1 = _configuration.GetSection("Llaves:RutaServicio").Value;
                ruta1 += "/api/Proyecto/MedidaSelectListAll?idCliente=" + medida.idCliente;
                var resultado1 = modelo.ConsultarMedidaSelectList(ruta1);
                ViewBag.Lista = resultado1;
                return View(medida);
            }
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ModificarMedida";

            string mensaje = modelo.ActualizarMedida(ruta, medida);
            if (mensaje == "Actualización exitosa")
            {

                return RedirectToAction("ConsultarMedidas", "DatosMedidas");
            }
            else
            {

                return View(medida);
            }
        }


    }
}
