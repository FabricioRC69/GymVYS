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
    }
}
/*
 using (var http = new HttpClient())
            {

                var stringPayload = JsonConvert.SerializeObject(cliente);

                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                using (var response = await http.PostAsync(ruta + cliente, httpContent))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cliente = JsonConvert.DeserializeObject<DatosCliente>(apiResponse);
                }
            }
 
 
 
 */



