using System.ComponentModel.DataAnnotations;

namespace GymVidaYSaludWEB.Entities
{
    public class UsuariosObj
    {
        [Display(Name = "Usuario ID")]
        public long idUsuario { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El campo Nombre de usuario debe ser una cadena con una longitud mínima de 3 y una longitud máxima de 30.")]
        [Display(Name = "Nombre de usuario")]
        public string NombreUsuario { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(30, ErrorMessage = "El campo correo electrónico tiene una longitud máxima de 30.")]
        [EmailAddress(ErrorMessage = "El correo ingresado no es valido. (ejemplo@correo.com)")]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo obligatorio")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "El campo contraseña tiene una longitud minima de 8 y máxima de 30.")]
        [Display(Name = "Contraseña")]
        public string Contraseña { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;


        public class RespuestaDatosUsuarios
        {
            public string Mensaje { get; set; } = string.Empty;
            public List<UsuariosObj> ListaDatos { get; set; } = null;
            public UsuariosObj Datos { get; set; } = null;
        }

    }
}
