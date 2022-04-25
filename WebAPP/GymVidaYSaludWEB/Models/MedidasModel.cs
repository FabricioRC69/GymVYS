using GymVidaYSaludWEB.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace GymVidaYSaludWEB.Models
{
    public class MedidasModel
    {
        public List<DatosMedidas> ConsultarMedidas(string ruta)
        {
            RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
            List<RespuestaDatosMedidas> lista = new List<RespuestaDatosMedidas>();

            using (var http = new HttpClient())
            {

                HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<RespuestaDatosMedidas>(datos);

                }

            }
            return resp.ListaDatos;

        }
        public List<SelectListItem> ConsultarMedidaSelectList(string ruta)
        {
            RespuestaDatosMedidaSelectList resp = new RespuestaDatosMedidaSelectList();
            List<SelectListItem> lista = new List<SelectListItem>();

            using (var http = new HttpClient())
            {

                HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<RespuestaDatosMedidaSelectList>(datos);

                }
                foreach (var item in resp.ListaDatos)
                {
                    lista.Add(new SelectListItem { Value = item.idCliente.ToString(), Text = item.Cedula +" | "+ item.NombreCompleto });
                }

                return lista;

            }
        }
        public DatosMedidas ConsultarUnaMedida(string ruta)
        {
            RespuestaDatosMedidas resp = new RespuestaDatosMedidas();
            List<RespuestaDatosMedidas> lista = new List<RespuestaDatosMedidas>();

            using (var http = new HttpClient())
            {

                HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<RespuestaDatosMedidas>(datos);

                }

            }
            return resp.Datos;

        }
        public string RegistrarMedida(string ruta, DatosMedidas medida)
        {
            using (var client = new HttpClient())
            {

                JsonContent content = JsonContent.Create(medida);
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
        public string ActualizarMedida(string ruta, DatosMedidas medida)
        {
            using (var client = new HttpClient())
            {

                JsonContent content = JsonContent.Create(medida);
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
        public List<MedidasSelectObj> ConsultarTodosClientesMedidas(string ruta)
        {
            RespuestaDatosMedidaSelectList resp = new RespuestaDatosMedidaSelectList();
            List<RespuestaDatosMedidaSelectList> lista = new List<RespuestaDatosMedidaSelectList>();

            using (var http = new HttpClient())
            {

                HttpResponseMessage respuesta = http.GetAsync(ruta).Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var datos = respuesta.Content.ReadAsStringAsync().Result;
                    resp = JsonConvert.DeserializeObject<RespuestaDatosMedidaSelectList>(datos);

                }

            }
            return resp.ListaDatos;

        }

    }
}
