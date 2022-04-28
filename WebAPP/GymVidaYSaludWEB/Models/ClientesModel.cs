using GymVidaYSaludWEB.Entities;
using Newtonsoft.Json;
using System.Text;
using static GymVidaYSaludWEB.Entities.DatosCliente;

namespace GymVidaYSaludWEB.Models
{
    public class ClientesModel
    {
        public List<DatosCliente> ConsultarTodosClientes(string ruta)
        {
            RespuestaDatosClientes resp = new RespuestaDatosClientes();
            List<RespuestaDatosClientes> lista = new List<RespuestaDatosClientes>();

            using (var http = new HttpClient())
            {

                HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<RespuestaDatosClientes>(datos);

                }

            }
            return resp.ListaDatos;

        }

        public DatosCliente ConsultarUnCliente(string ruta)
        {
            RespuestaDatosClientes resp = new RespuestaDatosClientes();
            List<RespuestaDatosClientes> lista = new List<RespuestaDatosClientes>();

            using (var http = new HttpClient())
            {

                HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<RespuestaDatosClientes>(datos);

                }

            }
            return resp.Datos;

        }
    
        public string RegistrarCliente(string ruta, DatosCliente cliente)
        {
            using (var client = new HttpClient()) { 

            JsonContent content = JsonContent.Create(cliente);
                HttpResponseMessage respuesta = client.PostAsync(ruta, content).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return "Registro exitoso";

                }
                else {
                    return "Error";
                }

            
            }
                

        }
        public string ActualizarCliente(string ruta, DatosCliente idCliente)
        {
            using (var client = new HttpClient())
            {

                JsonContent content = JsonContent.Create(idCliente);
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
        public string EliminarCliente(string ruta) {
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