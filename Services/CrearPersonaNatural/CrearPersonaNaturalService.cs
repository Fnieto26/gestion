using GestionTerceros.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace GestionTerceros.Services.CrearPersonaNatural
{
    public class CrearPersonaNaturalService : ICrearPersonaNaturalService
    {
        private readonly IConfiguration _configuration;

        public CrearPersonaNaturalService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CrearPersonaNaturalResponseDTO CrearTerceroCc(CrearPersonaNaturalRequestDTO personaNatural)
        {
            string cadena = _configuration.GetConnectionString("DefaultConnection");
            CrearPersonaNaturalResponseDTO respuesta = new();

            using (OracleConnection con = new(cadena))
            {
                try
                {
                    con.Open();

                    using (OracleCommand command = new())
                    {
                        command.Connection = con;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "pr_crea_cc_siias";
                        command.BindByName = true;

                        command.Parameters.Add(new OracleParameter("un_TIPOID", OracleDbType.Varchar2, 100, personaNatural.un_TIPOID, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_cc", OracleDbType.Varchar2, 100, personaNatural.un_cc, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_NOM1", OracleDbType.Varchar2, 100, personaNatural.un_NOM1, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_NOM2", OracleDbType.Varchar2, 100, personaNatural.un_NOM2, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_APE1", OracleDbType.Varchar2, 100, personaNatural.un_APE1, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_APE2", OracleDbType.Varchar2, 100, personaNatural.un_APE2, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_TEL", OracleDbType.Varchar2, 100, personaNatural.un_TEL, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_CEL", OracleDbType.Varchar2, 100, personaNatural.un_CEL, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_DIR", OracleDbType.Varchar2, 100, personaNatural.un_DIR, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_EMAIL", OracleDbType.Varchar2, 100, personaNatural.un_EMAIL, ParameterDirection.Input));
                        command.Parameters.Add(new OracleParameter("un_Id", OracleDbType.Varchar2, 100, "", ParameterDirection.Output));
                        command.Parameters.Add(new OracleParameter("un_err", OracleDbType.Varchar2, 200, "", ParameterDirection.Output));

                        command.ExecuteNonQuery();

                        respuesta.un_Id = command.Parameters["un_Id"].Value.ToString();
                        respuesta.un_err = command.Parameters["un_err"].Value.ToString();

                        return respuesta;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return respuesta;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
