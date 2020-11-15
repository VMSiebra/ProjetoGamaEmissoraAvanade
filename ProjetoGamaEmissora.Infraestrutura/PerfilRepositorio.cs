using Microsoft.Extensions.Configuration;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Infraestrutura
{
    public class PerfilRepositorio : IPerfilRepositorio
    {
        private readonly IConfiguration _configuration;

        public PerfilRepositorio(IConfiguration configuration)
        {
             _configuration = configuration;            
        }
        

        public async Task<Perfil> RecuperarIdAsync(int id)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var sqlCmd = $@"SELECT *
                                        FROM PERFIL 
                                    WHERE PerfilID={id}";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                        while (reader.Read())
                        {
                            var profile = new Perfil(int.Parse(reader["PerfilID"].ToString()),
                                                reader["Descricao"].ToString());

                            return profile;
                        }

                        return default;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
