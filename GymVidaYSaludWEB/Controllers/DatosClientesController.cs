using GymVidaYSaludWEB.Entities;
using GymVidaYSaludWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static GymVidaYSaludWEB.Entities.DatosCliente;

namespace GymVidaYSaludWEB.Controllers
{
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
             
        return View(resultado);
        }


        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            var objeto = new DatosCliente();
            return View(objeto);
        }

        [HttpPost]
        public IActionResult RegistrarCliente(string Cedula, string NombreCompleto, string NumContacto, string Correo) {
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            

            var resultado = modelo.RegistrarCliente(ruta, Cedula, NombreCompleto, NumContacto, Correo);
            if (resultado==null)
            {

                return RedirectToAction("ConsultarTodosClientes", "DatosClientes");
            }
            else { 
            
            return View(cliente);
            }
        }


        public IActionResult Index()
        {

            return View();
        }

    }
}
