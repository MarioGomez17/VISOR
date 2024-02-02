using CAPA_ENTIDADES___VISOR_AEROPUERTOS.CLASES;
using Npgsql;

namespace CAPA_DATOS___VISOR_AEROPUERTOS.CLASES
{
    public class ReporteDA
    {
        readonly string Tabla = "REPORTE";
        readonly string CampoNombreUsuario = "NOMBRE_USUARIO";
        readonly string CampoApellidoUsuario = "APELLIDO_USUARIO";
        readonly string CampoIdentificacionUsuario = "IDENTIFICACION_USUARIO";
        readonly string CampoTelefonoUsuario = "TELEFONO_USUARIO";
        readonly string CampoCorreoUsuario = "CORREO_USUARIO";
        readonly string CampoFechaIdaUsuario = "FECHA_IDA_USUARIO";
        readonly string CampoFechaRegresoUsuario = "FECHA_REGRESO_USUARIO";
        readonly string CampoIdAeropuertoSalida = "ID_AEROPUERTO_SALIDA";
        readonly string CampoIdAeropuertoLlegada = "ID_AEROPUERTO_LLEGADA";

        public bool RegistrarVuelo(ReporteBE Reporte)
        {
            bool Bandera = false;
            string SQL = $"INSERT INTO public.\"{Tabla}\" " +
                $" (\"{CampoNombreUsuario}\", \"{CampoApellidoUsuario}\", \"{CampoIdentificacionUsuario}\", " +
                $"\"{CampoTelefonoUsuario}\", \"{CampoCorreoUsuario}\", " +
                $"\"{CampoFechaIdaUsuario}\", \"{CampoFechaRegresoUsuario}\", " +
                $"\"{CampoIdAeropuertoSalida}\", \"{CampoIdAeropuertoLlegada}\") VALUES " +
                $"('" + Reporte.NombreUsuario + "', '" + Reporte.ApellidoUsuario + "', '" + Reporte.IdentificacionUsuario + "', " +
                "'" + Reporte.TelefonoUsuario + "', '" + Reporte.CorreoUsuario + "', '" + Reporte.FechaIdaUsuario + "', " +
                "'" + Reporte.FechaRegresoUsuario + "', '" + Reporte.IdAeropuertoSalida + "', '" + Reporte.IdAeropuertoLlegada + "');";

            try
            {
                NpgsqlCommand Comando = new()
                {
                    CommandText = SQL,
                    Connection = ConexionDA.EstablecerConexion()
                };

                Comando.ExecuteNonQuery();
                Bandera = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                ConexionDA.ConexionBD.Close();
            }
            return Bandera;
        }

        public static List<ReporteVistaBE> TraerReporte()
        {
            List<ReporteVistaBE> Reportes = new();
            string Tabla1 = "REPORTE";
            string Tabla2 = "AEROPUERTO_SALIDA";
            string Tabla3 = "AEROPUERTO_LLEGADA";
            string Tabla4 = "AEROPUERTO";
            string Campo1 = "NOMBRE_USUARIO";
            string Campo2 = "APELLIDO_USUARIO";
            string Campo3 = "IDENTIFICACION_USUARIO";
            string Campo4 = "TELEFONO_USUARIO";
            string Campo5 = "CORREO_USUARIO";
            string Campo6 = "FECHA_IDA_USUARIO";
            string Campo7 = "FECHA_REGRESO_USUARIO";
            string Campo8 = "NOMBRE";
            string Campo9 = "PAIS";
            string Campo10 = "CIUDAD";
            string Campo11 = "FOTO";
            string Campo12 = "ID_AEROPUERTO_SALIDA";
            string Campo13 = "ID_AEROPUERTO_LLEGADA";
            string Campo14 = "ID_AEROPUERTO";
            string Campo15 = "ID_REPORTE";

            string SQL = $"SELECT \"{Tabla1}\".\"{Campo1}\", \"{Tabla1}\".\"{Campo2}\", \"{Tabla1}\".\"{Campo3}\", " +
                         $"\"{Tabla1}\".\"{Campo4}\", \"{Tabla1}\".\"{Campo5}\", \"{Tabla1}\".\"{Campo6}\", \"{Tabla1}\".\"{Campo7}\", " +
                         $"\"{Tabla2}\".\"{Campo8}\", \"{Tabla2}\".\"{Campo9}\", \"{Tabla2}\".\"{Campo10}\", \"{Tabla2}\".\"{Campo11}\", " +
                         $"\"{Tabla3}\".\"{Campo8}\", \"{Tabla3}\".\"{Campo9}\", \"{Tabla3}\".\"{Campo10}\", \"{Tabla3}\".\"{Campo11}\" " +
                         $"FROM PUBLIC.\"{Tabla1}\" " +
                         $"JOIN PUBLIC.\"{Tabla4}\" AS \"{Tabla2}\" " +
                         $"ON PUBLIC.\"{Tabla1}\".\"{Campo12}\" = \"{Tabla2}\".\"{Campo14}\" " +
                         $"JOIN PUBLIC.\"{Tabla4}\" AS \"{Tabla3}\" " +
                         $"ON PUBLIC.\"{Tabla1}\".\"{Campo13}\" = \"{Tabla3}\".\"{Campo14}\" " +
                         $"ORDER BY \"{Campo15}\" ASC ";
            ReporteVistaBE Reporte;
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
                        Reporte = new()
                        {
                            NombreUsuario = Reader.GetString(0),
                            ApellidoUsuario = Reader.GetString(1),
                            IdentificacionUsuario = Reader.GetString(2),
                            TelefonoUsuario = Reader.GetString(3),
                            CorreoUsuario = Reader.GetString(4),
                            FechaSalidaUsuario = Reader.GetString(5),
                            FechaRegresoUsuario = Reader.GetString(6),
                            NombreAeropuertoSalida = Reader.GetString(7),
                            PaisAeropuertoSalida = Reader.GetString(8),
                            CiudadAeropuertoSalida = Reader.GetString(9),
                            FotoAeropuertoSalida = Reader.GetString(10),
                            NombreAeropuertoLlegada = Reader.GetString(11),
                            PaisAeropuertoLlegada = Reader.GetString(12),
                            CiudadAeropuertoLlegada = Reader.GetString(13),
                            FotoAeropuertoLlegada = Reader.GetString(14)
                        };
                        Reportes.Add(Reporte);
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
            return Reportes;
        }

    }
}
