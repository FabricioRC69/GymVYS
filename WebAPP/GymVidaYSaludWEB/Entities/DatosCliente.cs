using GymVidaYSaludWEB.Controllers;
using GymVidaYSaludWEB.Models;
using System.ComponentModel.DataAnnotations;


namespace GymVidaYSaludWEB.Entities
{



    public class DatosCliente
    {
        

        [Display(Name = "Cliente ID")]
        public long idCliente { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El campo Cédula debe ser una cadena con una longitud mínima de 3 y una longitud máxima de 30.")]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El campo Nombre completo debe ser una cadena con una longitud mínima de 3 y una longitud máxima de 30.")]
        [Display(Name = "Nombre completo")]
        public string NombreCompleto { get; set; } = string.Empty;

        [Display(Name = "Dia pago de cada mes")]
        public string Dia_de_Pago_Cada_Mes { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "El campo Número de contacto debe ser una cadena con una longitud mínima de 3 y una longitud máxima de 30.")]
        [Display(Name = "Número de contacto")]
        public string NumContacto { get; set; } = string.Empty;

        [Required(ErrorMessage="Campo obligatorio")]
        [StringLength(50, MinimumLength = 0)]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage ="El correo ingresado no es valido. (ejemplo@correo.com)")]
        public string Correo { get; set; } = string.Empty;

        public class CorreoClienteObj
        {
            public string Correo { get; set; } = string.Empty;
        }
        public class NumeroClienteObj
        {
            public string NumContacto { get; set; } = string.Empty;
        }
        public class CedulaClienteObj
        {
            public string Cedula { get; set; } = string.Empty;
        }
        public class RespuestaDatosClientes
        {
            public string Mensaje { get; set; } = string.Empty;
            public List<DatosCliente> ListaDatos { get; set; } = null;
            public DatosCliente Datos { get; set; } = null;
        }
        public class RespuestaCorreoCliente
        {
            public string Mensaje { get; set; } = string.Empty;
            public List<CorreoClienteObj> ListaDatos { get; set; } = null;
            public CorreoClienteObj Datos { get; set; } = null;
        }
        public class RespuestaNumeroCliente
        {
            public string Mensaje { get; set; } = string.Empty;
            public List<NumeroClienteObj> ListaDatos { get; set; } = null;
            public NumeroClienteObj Datos { get; set; } = null;
        }
        public class RespuestaCedulaCliente
        {
            public string Mensaje { get; set; } = string.Empty;
            public List<CedulaClienteObj> ListaDatos { get; set; } = null;
            public CedulaClienteObj Datos { get; set; } = null;
        }


        //public class EmailExistAttribute : ValidationAttribute
        //{
        //    ClientesModel modelo = new ClientesModel();

      

        //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //    {
             
        //        string ruta = "https://localhost:7164/api/Proyecto/ValidarCorreoCliente?correo=" + value;
        //        var resultado = modelo.ValidarCorreoCliente(ruta);

        //        if(resultado != null)
        //        {

        //            return new ValidationResult("El correo ingresado ya esta en uso");
        //        }

        //        return ValidationResult.Success;
        //    }
        //}
        //public class PhoneExistAttribute : ValidationAttribute
        //{
        //    ClientesModel modelo = new ClientesModel();



        //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //    {
        //        string ruta = "https://localhost:7164/api/Proyecto/ValidarNumeroCliente?numero=" + value;
        //        var resultado = modelo.ValidarNumeroCliente(ruta);

        //        if (resultado != null)
        //        {
        //            return new ValidationResult("El numero de contacto ingresado ya esta en uso");
        //        }

        //        return ValidationResult.Success;
        //    }
        //}
        //public class CedulaExistAttribute : ValidationAttribute
        //{
        //    ClientesModel modelo = new ClientesModel();



        //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //    {
        //        string ruta = "https://localhost:7164/api/Proyecto/ValidarCedulaCliente?cedula=" + value;
        //        var resultado = modelo.ValidarNumeroCliente(ruta);

        //        if (resultado != null)
        //        {
        //            return new ValidationResult("La cédula ingresada ya esta en uso");
        //        }

        //        return ValidationResult.Success;
        //    }
        //}


    }
}
