﻿using GymVidaYSaludWEB.Entities;
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
        public IActionResult ConsultarUnCliente(long idCliente)
        {

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnCliente?idCliente=" + idCliente;
            var resultado = modelo.ConsultarUnCliente(ruta);
            return View(resultado);
        }


        [HttpGet]
        public IActionResult RegistrarCliente()
        {
            var objeto = new DatosCliente();
            return View(objeto);
        }

        [HttpPost]
        public IActionResult RegistrarCliente(DatosCliente cliente) {
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/RegistrarCliente";

            string mensaje = modelo.RegistrarCliente(ruta, cliente);
            if (mensaje == "Registro exitoso")
            {

                return RedirectToAction("ConsultarTodosClientes", "DatosClientes");
            }
            else {

                return View(cliente);
            }
        }
        [HttpGet]
        public IActionResult ActualizarCliente(long idcliente)
        {


            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnCliente?idCliente=" + idcliente;
            var resultado = modelo.ConsultarUnCliente(ruta);

            return View(resultado);

        }

        [HttpPost]
        public IActionResult ActualizarCliente(DatosCliente cliente)
        {
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
