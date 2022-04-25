using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymVidaYSaludWEB.Entities
{
    public class DatosMedidas
    {
        public long idMedidas { get; set; }
        public decimal Peso { get; set; }
        public decimal Altura { get; set; } 
        public decimal Hombro { get; set; }
        public decimal Pecho { get; set; }
        public decimal Cadera { get; set; }
        public decimal Abdomen { get; set; }
        public decimal Cintura { get; set; }
        public decimal BicepD { get; set; }
        public decimal BicepI { get; set; }
        public decimal MusloD { get; set; }
        public decimal MusloI { get; set; }
        public decimal PantorrillaD { get; set; }
        public decimal PantorrillaI { get; set; }
        public long idCliente { get; set; }
    }
    public class MedidasSelectObj
    {
        public long idCliente { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
    }

    public class RespuestaDatosMedidas 
    { 
        public string Mensaje { get; set; } = string.Empty;
        public List<DatosMedidas> ListaDatos { get; set; } = null;
        public DatosMedidas Datos { get; set; } = null;
    }
    public class RespuestaDatosMedidaSelectList
    {
        public string Mensaje { get; set; } = string.Empty;
        public List<MedidasSelectObj> ListaDatos { get; set; } = null;
        public MedidasSelectObj Datos { get; set; } = null;

    }
    //public class RespuestaDatosMedidaSelectList
    //{
    //    public string Mensaje { get; set; } = string.Empty;
    //    public List<SelectListItem> ListaDatos { get; set; } = null;
    //    public SelectListItem Datos { get; set; } = null;

    //}
}
