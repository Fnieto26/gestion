using GestionTerceros.Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.Metadata;

namespace GestionTerceros.Services.ExisteTercero
{
    public class ExisteTerceroService : IExisteTerceroService
    {
        private readonly IConfiguration _configuration;

        public ExisteTerceroService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public GestionTercerosResponseDTO ExisteTercero(GestionTercerosRequestDTO gestionTercerosRequestDTO)
        {

            GestionTercerosResponseDTO response = new GestionTercerosResponseDTO();

            string cadena = _configuration.GetConnectionString("DefaultConnection");

            using (OracleConnection connection = new(cadena))
            {
                try
                {
                    connection.Open();

                    using (OracleCommand command = new())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "trc_pg_svcio_infbasica.PR_existe_tercero";
                        command.BindByName = true;

                        command.Parameters.Add("una_identificacion", OracleDbType.Varchar2, 100, gestionTercerosRequestDTO.una_identificacion, ParameterDirection.Input);
                        command.Parameters.Add("un_tipo_ident", OracleDbType.Varchar2, 100, gestionTercerosRequestDTO.un_tipo_ident, ParameterDirection.Input);
                        command.Parameters.Add("una_existencia", OracleDbType.Varchar2, 300, "", ParameterDirection.Output);
                        command.Parameters.Add("un_Interno_erp", OracleDbType.Varchar2, 300, "", ParameterDirection.Output);

                        command.ExecuteNonQuery();

                        var existencia = command.Parameters["una_existencia"].Value;
                        var interno = command.Parameters["un_Interno_erp"].Value;

                        response.una_existencia = ((OracleString)existencia).Value.ToString();
                        response.un_Interno_erp = ((OracleString)interno).Value.ToString();

                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return response;
            }

        }
    }
}
