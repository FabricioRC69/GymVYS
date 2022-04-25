using GymVidaYSaludWEB.Entities;
using Newtonsoft.Json;
using static GymVidaYSaludWEB.Entities.UsuariosObj;

namespace GymVidaYSaludWEB.Models
{
    public class UsuarioModel
    {
        public List<UsuariosObj> ConsultarUsuarios(string ruta)
        {
            RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
            List<RespuestaDatosUsuarios> lista = new List<RespuestaDatosUsuarios>();

            using (var http = new HttpClient())
            {

                HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<RespuestaDatosUsuarios>(datos);

                }

            }
            return resp.ListaDatos;

        }

        public UsuariosObj ConsultarUnUsuario(string ruta)
        {
            RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
            List<RespuestaDatosUsuarios> lista = new List<RespuestaDatosUsuarios>();

            using (var http = new HttpClient())
            {

                HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<RespuestaDatosUsuarios>(datos);

                }

            }
            return resp.Datos;

        }
        public UsuariosObj ConsultarUsuarioLogin(string ruta)
        {
            RespuestaDatosUsuarios resp = new RespuestaDatosUsuarios();
            List<RespuestaDatosUsuarios> lista = new List<RespuestaDatosUsuarios>();

            using (var http = new HttpClient())
            {

                HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<RespuestaDatosUsuarios>(datos);

                }

            }
            return resp.Datos;

        }

        public string RegistraUsuario(string ruta, UsuariosObj usuario)
        {
            using (var client = new HttpClient())
            {

                JsonContent content = JsonContent.Create(usuario);
                HttpResponseMessage respuesta = client.PostAsync(ruta, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return "Registro exitoso";
                }
                else
                {
                    return "Error";
                }
            }
            
        }
        public string ActualizarUsuario(string ruta, UsuariosObj idUsuario)
        {
            using (var client = new HttpClient())
            {

                JsonContent content = JsonContent.Create(idUsuario);
                HttpResponseMessage respuesta = client.PutAsync(ruta, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {

                    return "Actualización exitosa";

                }
                else
                {
                    return "Error";
                }


            }


        }
        public string ActualizarUsuarioSinPermisos(string ruta, UsuariosObj idUsuario)
        {
            using (var client = new HttpClient())
            {

                JsonContent content = JsonContent.Create(idUsuario);
                HttpResponseMessage respuesta = client.PutAsync(ruta, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {

                    return "Actualización exitosa";

                }
                else
                {
                    return "Error";
                }


            }


        }
        public string EliminarUsuario(string ruta)
        {
            using (var client = new HttpClient())
            {


                HttpResponseMessage respuesta = client.DeleteAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return "Eliminador Correctamente";

                }
                else
                {
                    return null;

                }


            }

        }

    }
}
