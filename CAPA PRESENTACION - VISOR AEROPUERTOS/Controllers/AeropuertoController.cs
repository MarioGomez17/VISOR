using CAPA_LOGICA____VISOR_AEROPUERTOS.CLASES;
using Microsoft.AspNetCore.Mvc;

namespace VISOR_AEROPUERTOS.Controllers
{
    public class AeropuertoController : Controller
    {
        [HttpGet]
        public JsonResult TraerCiudades(string Pais)
        {
            AeropuertoBL AeropuertoBL = new();
            return Json(AeropuertoBL.TraerCiudades(Pais));
        }

        [HttpGet]
        public JsonResult TraerAeropuertos(string Ciudad)
        {
            AeropuertoBL AeropuertoBL = new();
            return Json(AeropuertoBL.TraerAeropuertos(Ciudad));
        }

        public JsonResult TraerFoto(string Aeropuerto)
        {
            AeropuertoBL AeropuertoBL = new();
            return Json(AeropuertoBL.TraerFoto(Aeropuerto));
        }
    }
}
