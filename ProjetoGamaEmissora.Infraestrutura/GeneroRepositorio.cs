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
    public class GeneroRepositorio : IGeneroRepositorio
    {
        private readonly IConfiguration _configuration;
        public GeneroRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Genero>> GetGeneroIdAsync(List<int> id)
        {
            try
            {

                var genres = new List<Genero>();

                for (int i = 0; i <= id.Count - 1; i++)
                {
                    using (var con = new SqlConnection(_configuration["ConnectionString"]))
                    {
                        var sqlCmd = $@"SELECT GeneroID,
                                               Descricao 
                                        FROM GENERO 
                                    WHERE GeneroID={id[i]}";

                        using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();

                            var reader = await cmd
                                                .ExecuteReaderAsync()
                                                .ConfigureAwait(false);

                            while (reader.Read())
                            {
                                var genre = new Genero(int.Parse(reader["GeneroID"].ToString()),
                                                    reader["Descricao"].ToString());

                                genres.Add(genre);
                            }

                        }
                    }
                }

                return genres;

            } 
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
