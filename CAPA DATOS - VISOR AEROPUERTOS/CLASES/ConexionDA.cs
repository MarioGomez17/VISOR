using Npgsql;

namespace CAPA_DATOS___VISOR_AEROPUERTOS.CLASES
{
    public class ConexionDA
    {

        public readonly static NpgsqlConnection ConexionBD = new();

        static readonly String servidor = "localhost";
        static readonly String bd = "aeropuertos";
        static readonly String usuario = "postgres";
        static readonly String password = "M@rio1002960089";
        static readonly String puerto = "5432";

        public static readonly String cadenaConexion = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + usuario + ";" + "password=" + password + ";" + "database=" + bd + ";";

        public static NpgsqlConnection EstablecerConexion()
        {
            try
            {
                ConexionBD.ConnectionString = cadenaConexion;
                ConexionBD.Open();
            }
            catch (NpgsqlException e)
            { 
                Console.WriteLine(e.ToString());
            }
            return ConexionBD;
        }

    }
}
