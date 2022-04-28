using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GymVidaYSaludWEB.Entities
{
    public class DatosMedidas
    {
        
        public long idMedidas { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? Peso { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? Altura { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? Hombro { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? Pecho { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? Cadera { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? Abdomen { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? Cintura { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? BicepD { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? BicepI { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? MusloD { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? MusloI { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? PantorrillaD { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        public decimal? PantorrillaI { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Tiene que estar entre 0 y 10000000000000000.")]
        [Display(Name = "Cliente ID")]
        public long? idCliente { get; set; }
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
