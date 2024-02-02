using CAPA_DATOS___VISOR_AEROPUERTOS.CLASES;
using CAPA_ENTIDADES___VISOR_AEROPUERTOS.CLASES;

namespace CAPA_LOGICA____VISOR_AEROPUERTOS.CLASES
{
    public class AeropuertoBL
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public static List<string> TraerPaises()
        {
            return AeropuertoDA.TraerPaises();
        }

        public static List<string> TraerCiudades(string Pais)
        {
            return AeropuertoDA.TraerCiudades(Pais);
        }

        public static List<AeropuertoBE> TraerAeropuertos(string Ciudad)
        {
            return AeropuertoDA.TraerAeropuertos(Ciudad);
        }

        public static string TraerFoto(string Aeropuerto)
        {
            return AeropuertoDA.TraerFoto(Aeropuerto);
        }

    }
}
