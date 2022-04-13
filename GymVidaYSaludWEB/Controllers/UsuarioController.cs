using GymVidaYSaludWEB.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static GymVidaYSaludWEB.Entities.DatosCliente;
using static GymVidaYSaludWEB.Entities.UsuariosObj;

namespace GymVidaYSaludWEB.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> ConsultarLogin(string correo, string constrasena)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
                    ruta += "/api/Proyecto/ConsultarLogin?Correo=" + correo + "&contrasena=" + constrasena;

                    HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        //recuperar el datos de listaDatos de la respuesta
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        var datosOBJ = JsonConvert.DeserializeObject<RespuestaDatosUsuarios>(datos);
                        if (datosOBJ.Datos != null)
                        {
                            //guardar en la sesion
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Login", "Usuario");
                        }
                    }
                    return RedirectToAction("Login", "Usuario");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarUsuario(string correo, string constrasena, string Rol)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    string ruta = _configuration.GetSection("Llaves:RutaServicio").Value;
                   ruta += "/api/Proyecto/RegistrarUsuario?Correo="+correo+"&contraseña="+ constrasena + "&Rol="+Rol;

                    HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Login", "LogIn");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Register");
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Register");
                throw;
            }
        }

        public IActionResult Register()
        {
            return View();
        }
    }

}

