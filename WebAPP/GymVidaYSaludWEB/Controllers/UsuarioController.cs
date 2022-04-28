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

        [HttpGet]
        public IActionResult ConsultarUsuarios()
        {
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUsuarios";
            var resultado = modelo.ConsultarUsuarios(ruta);

            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;

            return View(resultado);
        }


        [HttpGet]
        public IActionResult ConsultarUnUsuario(long idUsuario)
        {

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnUsuario?idUsuario=" + idUsuario;
            var resultado = modelo.ConsultarUnUsuario(ruta);

            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;

            return View(resultado);
        }
        [FiltroDeSesion]
        [HttpGet]
        public IActionResult ConsultarPerfil(long idUsuario)
        {

            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnUsuario?idUsuario=" + idUsuario;
            var resultado = modelo.ConsultarUnUsuario(ruta);

            var IdUsuario = HttpContext.Session.GetString("idUsuario");
            ViewBag.idUsuario = IdUsuario;
            return View(resultado);
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
                    HttpContext.Session.SetString("NombreUsuario", resultado.NombreUsuario);
                    HttpContext.Session.SetString("Correo", Correo);
                    HttpContext.Session.SetString("Rol", resultado.Rol);
                    HttpContext.Session.SetString("idUsuario", resultado.idUsuario.ToString());
                    return RedirectToAction("Index", "Home");

                }
                else 
                {
                    return RedirectToAction("LogIn", "Usuario");
                }
            }
        }
        [FiltroDeSesion]
        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;
            var objeto = new UsuariosObj();
            return View(objeto);
        }
        [FiltroDeSesion]
        [HttpPost]
        public IActionResult RegistrarUsuario(UsuariosObj usuario)
        {
            if (!ModelState.IsValid)
            {
                var usuario2 = HttpContext.Session.GetString("NombreUsuario");
                ViewBag.Usuario = usuario2;
                var correo = HttpContext.Session.GetString("Correo");
                ViewBag.Correo = correo;
                var rol = HttpContext.Session.GetString("Rol");
                ViewBag.Rol = rol;

                return View(usuario);
            }
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/RegistrarUsuario";


            string mensaje = modelo.RegistraUsuario(ruta, usuario);
            if (mensaje == "Registro exitoso")
            {
                return RedirectToAction("ConsultarUsuarios", "Usuario");
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
        [FiltroDeSesion]
        [HttpGet]
        public IActionResult ActualizarUsuario(long idUsuario)
        {

            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnUsuario?idUsuario=" + idUsuario;
            var resultado = modelo.ConsultarUnUsuario(ruta);

            return View(resultado);

        }

        [FiltroDeSesion]
        [HttpPost]
        public IActionResult ActualizarUsuario(UsuariosObj usuario)
        {
            if (!ModelState.IsValid)
            {
                var usuario2 = HttpContext.Session.GetString("NombreUsuario");
                ViewBag.Usuario = usuario2;
                var correo = HttpContext.Session.GetString("Correo");
                ViewBag.Correo = correo;
                var rol = HttpContext.Session.GetString("Rol");
                ViewBag.Rol = rol;

                string ruta2 = _configuration.GetSection("Llaves:RutaServicio").Value;
                ruta2 += "/api/Proyecto/ConsultarUnUsuario?idUsuario=" + usuario.idUsuario;
                var resultado = modelo.ConsultarUnUsuario(ruta2);

                return View(resultado);
            }
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ModificarUsuario";

            var IdUsuario = HttpContext.Session.GetString("idUsuario");
            ViewBag.idUsuario = IdUsuario;
            var valor = long.Parse(IdUsuario);

            if (usuario.idUsuario == valor)
            {
                HttpContext.Session.SetString("NombreUsuario", usuario.NombreUsuario);
                HttpContext.Session.SetString("Correo", usuario.Correo);
                HttpContext.Session.SetString("Rol", usuario.Rol);
                HttpContext.Session.SetString("idUsuario", usuario.idUsuario.ToString());
            }
        

            string mensaje = modelo.ActualizarUsuario(ruta, usuario);
            if (mensaje == "Actualización exitosa")
            {

                return RedirectToAction("ConsultarUsuarios", "Usuario");
            }
            else
            {

                return View(usuario);
            }
        }
        [FiltroDeSesion]
        [HttpGet]
        public IActionResult ActualizarPerfil(string idUsuario)
        {
            
            var usuario = HttpContext.Session.GetString("NombreUsuario");
            ViewBag.Usuario = usuario;
            var correo = HttpContext.Session.GetString("Correo");
            ViewBag.Correo = correo;
            var rol = HttpContext.Session.GetString("Rol");
            ViewBag.Rol = rol;

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ConsultarUnUsuario?idUsuario=" + idUsuario;
            var resultado = modelo.ConsultarUnUsuario(ruta);
            

            return View(resultado);

        }
        [FiltroDeSesion]
        [HttpPost]
        public IActionResult ActualizarPerfil(UsuariosObj usuario)
        {

            if (!ModelState.IsValid)
            {

                string ruta2 = _configuration.GetSection("Llaves:RutaServicio").Value;
                ruta2 += "/api/Proyecto/ConsultarUnUsuario?idUsuario=" + usuario.idUsuario;
                var resultado = modelo.ConsultarUnUsuario(ruta2);

                var usuario2 = HttpContext.Session.GetString("NombreUsuario");
                ViewBag.Usuario = usuario2;
                var correo = HttpContext.Session.GetString("Correo");
                ViewBag.Correo = correo;
                var rol = HttpContext.Session.GetString("Rol");
                ViewBag.Rol = rol;

                return View(resultado);
            }

            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/ModificarUsuarioSinPermisos";
            string mensaje = "";

                mensaje = modelo.ActualizarUsuarioSinPermisos(ruta, usuario);


            if (mensaje == "Actualización exitosa")
            {
                string ruta3 = _configuration.GetSection("Llaves:RutaServicio").Value;
                ruta3 += "/api/Proyecto/ConsultarUnUsuario?idUsuario=" + usuario.idUsuario.ToString();
                var resultado = modelo.ConsultarUnUsuario(ruta3);

                HttpContext.Session.SetString("NombreUsuario", resultado.NombreUsuario);
                HttpContext.Session.SetString("Correo", resultado.Correo);
                HttpContext.Session.SetString("Rol", resultado.Rol);
                HttpContext.Session.SetString("idUsuario", resultado.idUsuario.ToString());

                return RedirectToAction("ConsultarPerfil", new RouteValueDictionary(new { Controller="usuario", Action="consultarperfil",idUsuario = usuario.idUsuario }));
            }
            else
            {

                return View(usuario);
            }
        }
        [FiltroDeSesion]
        [HttpGet]
        public IActionResult EliminarUsuario(long idUsuario)
        {
      

                string respuesta = "";
            string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
            ruta += "/api/Proyecto/EliminarUsuario?idUsuario=" + idUsuario;
            respuesta = modelo.EliminarUsuario(ruta);

            var IdUsuario = HttpContext.Session.GetString("idUsuario");
            ViewBag.idUsuario = IdUsuario;
            var valor = long.Parse(IdUsuario);

            if (idUsuario == valor)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("LogIn", "Usuario");

            }
            return RedirectToAction("ConsultarUsuarios", "Usuario");
            
            /*if (respuesta != null)
            {
                return RedirectToAction("ConsultarTodosClientes", "DatosClientes");
            }
            else {

                return RedirectToAction("RegistrarCliente", "DatosClientes"); ;    
            }*/
        }

    }
}

