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

        public async Task<int> InserirProdutorAsync(Produtor produtor)
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
                        cmd.Parameters.AddWithValue("UsuarioID", produtor._UsuarioID);
                        cmd.Parameters.AddWithValue("Nome", produtor._Nome); 
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

        public async Task<int> ConsultarProdutorUsuarioIdAsync(int UserId)
        {
            try
            {
                using (var con = new SqlConnection(_Configuration["ConnectionString"]))
                {
                    con.Open();


                    var sqlCmd = @"SELECT
                                    A.UsuarioID,
                                    A.ProdutorID                                   
                                FROM PRODUTOR A
                                    WHERE A.[UsuarioID] = @Id";

                    using (var cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", UserId);

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                        if (reader.Read())
                        {
                            return int.Parse(reader["UsuarioID"].ToString());
                        }

                        return 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produtor> ConsultarProdutorAsync(int id)
        {
            try
            {
                using (var con = new SqlConnection(_Configuration["ConnectionString"]))
                {
                    con.Open();


                    var sqlCmd = @"SELECT
                                    A.UsuarioID,
                                    A.ProdutorID,
                                    A.Nome                                   
                                FROM PRODUTOR A
                                    WHERE A.[ProdutorID] = @Id";

                    using (var cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);                                    

                        while (reader.Read())
                        {       
                            var produtor = new Produtor(
                                             int.Parse(reader["UsuarioID"].ToString()),
                                             int.Parse(reader["AtorID"].ToString()),
                                             reader["Nome"].ToString()                                            
                                         );

                            return produtor;
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
