using Microsoft.Extensions.Configuration;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Infraestrutura
{
    public class ProdutorRepositorio : IProdutorRepositorio
    {
        private readonly IConfiguration _Configuration;

        public ProdutorRepositorio(IConfiguration config)
        {
            _Configuration = config;
        }

        public async Task<int> InserirProdutorAsync(Ator ator)
        {
            try
            {
                using (var con = new SqlConnection(_Configuration["ConnectionString"]))
                {
                    var sqlCmd = @"INSERT INTO 
                                    PRODUTOR (
                                         UsuarioID
                                        ,Nome                                       
                                        ) 
                                    VALUES (
                                        @UsuarioID,
                                        @Nome                                        
                                        ); 
                                    SELECT scope_identity();";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;                       
                        cmd.Parameters.AddWithValue("UsuarioID", ator._UsuarioID);
                        cmd.Parameters.AddWithValue("Nome", ator._Nome); 
                        con.Open();
                        var id = await cmd
                                        .ExecuteScalarAsync()
                                        .ConfigureAwait(false); 
                        return int.Parse(id.ToString());
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
