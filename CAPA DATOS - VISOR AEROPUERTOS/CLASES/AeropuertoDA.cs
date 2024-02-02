using CAPA_ENTIDADES___VISOR_AEROPUERTOS.CLASES;
using Npgsql;

namespace CAPA_DATOS___VISOR_AEROPUERTOS.CLASES
{
    public class AeropuertoDA
    {
        public static List<string> TraerPaises()
        {
            List<string> Paises = new();
            string Tabla = "AEROPUERTO";
            string Campo = "PAIS";
            string SQL = $"SELECT DISTINCT public.\"{Tabla}\".\"{Campo}\" FROM public.\"{Tabla}\" ORDER BY public.\"{Tabla}\".\"{Campo}\" ASC";
            try
            {
                NpgsqlCommand Comando = new()
                {
                    CommandText = SQL,
                    Connection = ConexionDA.EstablecerConexion()
                };

                NpgsqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Paises.Add(Reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                ConexionDA.ConexionBD.Close();
            }
            return Paises;
        }

        public static List<string> TraerCiudades(string Pais)
        {
            List<string> Ciudades = new();
            string Tabla = "AEROPUERTO";
            string Campo = "CIUDAD";
            string Campo2 = "PAIS";
            string SQL = $"SELECT DISTINCT public.\"{Tabla}\".\"{Campo}\" FROM public.\"{Tabla}\" WHERE public.\"{Tabla}\".\"{Campo2}\" = '" + Pais + $"'ORDER BY public.\"{Tabla}\".\"{Campo}\" ASC";
            try
            {
                NpgsqlCommand Comando = new()
                {
                    CommandText = SQL,
                    Connection = ConexionDA.EstablecerConexion()
                };

                NpgsqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Ciudades.Add(Reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                ConexionDA.ConexionBD.Close();
            }
            return Ciudades;
        }

        public static List<AeropuertoBE> TraerAeropuertos(string Ciudad)
        {
            List<AeropuertoBE> Aeropuertos = new();
            string Tabla = "AEROPUERTO";
            string Campo = "NOMBRE";
            string Campo2 = "ID_AEROPUERTO";
            string Campo3 = "CIUDAD";
            string SQL = $"SELECT public.\"{Tabla}\".\"{Campo2}\", public.\"{Tabla}\".\"{Campo}\"  FROM public.\"{Tabla}\" WHERE public.\"{Tabla}\".\"{Campo3}\" = '" + Ciudad + $"'  ORDER BY public.\"{Tabla}\".\"{Campo}\" ASC";
            AeropuertoBE AeropuertoBE;
            try
            {
                NpgsqlCommand Comando = new()
                {
                    CommandText = SQL,
                    Connection = ConexionDA.EstablecerConexion()
                };

                NpgsqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        AeropuertoBE = new()
                        {
                            Id = Reader.GetInt32(0),
                            Nombre = Reader.GetString(1)
                        };
                        Aeropuertos.Add(AeropuertoBE);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                ConexionDA.ConexionBD.Close();
            }
            return Aeropuertos;
        }

        public static string TraerFoto(string Aeropuerto)
        {
            string Foto = "No obtuve datos";
            string Tabla = "AEROPUERTO";
            string Campo = "FOTO";
            string Campo2 = "ID_AEROPUERTO";
            string SQL = $"SELECT DISTINCT public.\"{Tabla}\".\"{Campo}\" FROM public.\"{Tabla}\" WHERE public.\"{Tabla}\".\"{Campo2}\" = '" + Aeropuerto + "' LIMIT 1";
            try
            {
                NpgsqlCommand Comando = new()
                {
                    CommandText = SQL,
                    Connection = ConexionDA.EstablecerConexion()
                };

                NpgsqlDataReader Reader = Comando.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        Foto = Reader.GetString(0);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                ConexionDA.ConexionBD.Close();
            }
            return Foto;
        }

    }
}
