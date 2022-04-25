﻿namespace GymVidaYSaludWEB.Entities
{



    public class DatosCliente
    {

        public long idCliente { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public string Dia_de_Pago_Cada_Mes { get; set; } = string.Empty;
        public string NumContacto { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;


        public class RespuestaDatosClientes
        {
            public string Mensaje { get; set; } = string.Empty;
            public List<DatosCliente> ListaDatos { get; set; } = null;
            public DatosCliente Datos { get; set; } = null;
        }



    }
}
