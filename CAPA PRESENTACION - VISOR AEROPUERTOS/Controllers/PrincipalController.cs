using CAPA_ENTIDADES___VISOR_AEROPUERTOS.CLASES;
using CAPA_LOGICA____VISOR_AEROPUERTOS.CLASES;
using Microsoft.AspNetCore.Mvc;
using System;

namespace VISOR_AEROPUERTOS.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Index()
        {
            PaisesBE AeropuertoBE = new()
            {
                Paises = AeropuertoBL.TraerPaises()
            };

            DateTime FechaActual = DateTime.Now;

            DateTime FechaSalida = FechaActual.AddDays(10);
            string FechaMinimaSalida = FechaSalida.ToString("yyyy-MM-ddTHH:mm");

            DateTime FechaRegreso = FechaSalida.AddDays(10);
            string FechaMinimoRegreso = FechaRegreso.ToString("yyyy-MM-ddTHH:mm");

            ViewBag.FechaMinimaSalida = FechaMinimaSalida;
            ViewBag.FechaMinimoRegreso = FechaMinimoRegreso;

            return View(AeropuertoBE);
        }

        public IActionResult RegistrarReporte(string NombreUsuario, string ApellidoUsuario,
            string IdentificacionUsuario, string TelefonoUsuario,
            string CorreoUsuario, DateTime FechaIdaUsuario,
            DateTime FechaRegresoUsuario, int IdAeropuertoSalida, int IdAeropuertoLlegada)
        {
            ReporteBE ReporteBE = new(NombreUsuario, ApellidoUsuario, IdentificacionUsuario,
                TelefonoUsuario, CorreoUsuario, FechaIdaUsuario.ToString(), FechaRegresoUsuario.ToString(),
                IdAeropuertoSalida, IdAeropuertoLlegada);
            ReporteBL.RegistrarVuelo(ReporteBE);
            Index();
            return View("Index");
        }

        public IActionResult Reporte()
        {
            Reportes Reportes = new()
            {
                ReportesVista = ReporteBL.TraerReporte()
            };
            return View(Reportes);
        }

        public JsonResult TraerFotoReportes(string Aeropuerto)
        {
            return Json(ReporteBL.TraerReporte());
        }

    }
}
