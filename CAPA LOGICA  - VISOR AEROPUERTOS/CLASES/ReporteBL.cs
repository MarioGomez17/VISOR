using CAPA_ENTIDADES___VISOR_AEROPUERTOS.CLASES;
using CAPA_DATOS___VISOR_AEROPUERTOS.CLASES;

namespace CAPA_LOGICA____VISOR_AEROPUERTOS.CLASES
{
    public class ReporteBL
    {

        public static bool RegistrarVuelo(ReporteBE ReporteBE)
        {
            ReporteDA ReporteDA = new();
            return ReporteDA.RegistrarVuelo(ReporteBE);
        }

        public static List<ReporteVistaBE> TraerReporte()
        {
            return ReporteDA.TraerReporte();
        }

    }
}
