using System;
using System.Collections.Generic;
namespace CAPA_ENTIDADES___VISOR_AEROPUERTOS.CLASES
{
    public class ReporteBE
    {
        public string? NombreUsuario { get; set; }
        public string? ApellidoUsuario { get; set; }
        public string? IdentificacionUsuario { get; set; }
        public string? TelefonoUsuario { get; set; }
        public string? CorreoUsuario { get; set; }
        public string? FechaIdaUsuario { get; set; }
        public string? FechaRegresoUsuario { get; set; }
        public int? IdAeropuertoSalida { get; set; }
        public int? IdAeropuertoLlegada { get; set; }

        public ReporteBE(string NombreUsuario, string ApellidoUsuario, 
            string IdentificacionUsuario, string TelefonoUsuario, 
            string CorreoUsuario, string FechaIdaUsuario,
            string FechaRegresoUsuario, int IdAeropuertoSalida, int IdAeropuertoLlegada)
        {
            this.NombreUsuario = NombreUsuario;
            this.ApellidoUsuario = ApellidoUsuario;
            this.IdentificacionUsuario = IdentificacionUsuario;
            this.TelefonoUsuario = TelefonoUsuario;
            this.CorreoUsuario = CorreoUsuario;
            this.FechaIdaUsuario = FechaIdaUsuario;
            this.FechaRegresoUsuario = FechaRegresoUsuario;
            this.IdAeropuertoSalida = IdAeropuertoSalida;
            this.IdAeropuertoLlegada = IdAeropuertoLlegada;
        }

    }
}
