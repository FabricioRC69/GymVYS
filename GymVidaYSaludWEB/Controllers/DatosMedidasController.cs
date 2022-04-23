using GymVidaYSaludWEB.Entities;
using GymVidaYSaludWEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymVidaYSaludWEB.Controllers
{
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

            return View(resultado);
        }


        [HttpGet]
        public IActionResult ConsultarUnaMedida(string cedula)
        {

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnaMedida?Cedula=" + cedula;
            var resultado = modelo.ConsultarUnaMedida(ruta);
            return View(resultado);

        }

        [HttpGet]
        public IActionResult RegistrarMedida()
        {
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/MedidaSelectList";
            var resultado = modelo.ConsultarMedidaSelectList(ruta);

            ViewBag.Lista = resultado;
            return View(new DatosMedidas());

        }

        [HttpPost]
        public IActionResult RegistrarMedida(DatosMedidas medida)
        {
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
        public IActionResult ActualizarMedida(string cedula)
        {


            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnaMedida?Cedula=" + cedula;
            var resultado = modelo.ConsultarUnaMedida(ruta);
            string ruta1 = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta1 += "/api/Proyecto/MedidaSelectListAll";
            var resultado1 = modelo.ConsultarMedidaSelectList(ruta1);

            ViewBag.Lista = resultado1;
            return View(resultado);

        }

        [HttpPost]
        public IActionResult ActualizarMedida(DatosMedidas medida)
        {
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
