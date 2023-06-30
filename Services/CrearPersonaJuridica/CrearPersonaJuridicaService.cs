using GestionTerceros.Models;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace GestionTerceros.Services.CrearPersonaJuridica
{
    public class CrearPersonaJuridicaService : ICrearPersonaJuridicaService
    {
        private readonly IConfiguration _configuration;

        public CrearPersonaJuridicaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public CrearPersonaJuridicaResponseDTO CrearTerceroNit(CrearPersonaJuridicaRequestDTO personaJuridica)
        {
            string cadena = _configuration.GetConnectionString("DefaultConnection");
            CrearPersonaJuridicaResponseDTO respuesta = new();

            using(OracleConnection con = new(cadena)) 
            {
                try
                {
                    con.Open();

                    using(OracleCommand cmd = new()) 
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "pr_crea_nit_siias";
                        cmd.BindByName = true;

                        cmd.Parameters.Add(new OracleParameter("un_TIPOID", OracleDbType.Varchar2, 100, personaJuridica.un_TIPOID, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("un_NIT", OracleDbType.Varchar2, 100, personaJuridica.un_NIT, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("un_NOMBRE", OracleDbType.Varchar2, 100, personaJuridica.un_NOMBRE, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("un_TEL", OracleDbType.Varchar2, 100, personaJuridica.un_TEL, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("un_DIR", OracleDbType.Varchar2, 100, personaJuridica.un_DIR, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("un_EMAIL", OracleDbType.Varchar2, 100, personaJuridica.un_EMAIL, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("un_Id", OracleDbType.Varchar2, 100, "", ParameterDirection.Output));
                        cmd.Parameters.Add(new OracleParameter("un_err", OracleDbType.Varchar2, 200, "", ParameterDirection.Output));

                        cmd.ExecuteNonQuery();

                        respuesta.un_Id = cmd.Parameters["un_Id"].Value.ToString();
                        respuesta.un_err = cmd.Parameters["un_err"].Value.ToString();

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
