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
    public class AtorRepositorio : IAtorRepositorio
    {
        private readonly IConfiguration _Configuration;

        public AtorRepositorio(IConfiguration config)
        {
            _Configuration = config; 
        }

        public IEnumerable<Ator> ConsultarAtores()
        {
            try
            {
                using (var con = new SqlConnection(_Configuration["ConnectionString"]))
                {
                    var atorLista = new List<Ator>();
                    var comandoSQL = @"SELECT 
                                    A.Nome, 
                                    A.Idade, 
                                    A.Sexo, 
                                    A.Cache, 
                                    A.Status, 
                                    A.Relevancia
                                    FROM ATOR A";

                    using (var cmd = new SqlCommand(comandoSQL, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = cmd.ExecuteReader();

                        var generoLista = new List<Genero>();

                        while (reader.Read())
                        {

                            //var comandoSQLGenero = @"SELECT G.GeneroID,
                            //                       G.Descricao
                            //                  FROM AtorGenero AG INNER JOIN Genero G ON AG.GeneroID = G.GeneroID
                            //                  WHERE AG.AtorID = @AtorID";

                            //using (var cmdGenero = new SqlCommand(comandoSQLGenero, con))
                            //{
                            //    cmdGenero.CommandType = CommandType.Text;
                            //    cmdGenero.Parameters.AddWithValue("@AtorID", reader["ActorId"].ToString());

                            //    var readerGenero = cmdGenero.ExecuteReader();

                            //    while (readerGenero.Read())
                            //    { 
                            //        var genero = new Genero(int.Parse(readerGenero["GeneroID"].ToString()),
                            //            readerGenero["Descricao"].ToString());
                            //        generoLista.Add(genero);
                            //    }

                            //}

                            var ator = new Ator(
                                            reader["Nome"].ToString(),
                                            int.Parse(reader["Idade"].ToString()),
                                            reader["Sexo"].ToString(),                                            
                                            generoLista,
                                            double.Parse(reader["Cache"].ToString()),
                                            reader["Status"].ToString(),
                                            int.Parse(reader["Relevancia"].ToString())
                                        );

                            atorLista.Add(ator);
                        }

                        return atorLista;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        Task<Ator> IAtorRepositorio.ConsultarItemAtorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> IAtorRepositorio.InserirAtorAsync(Ator ator)
        {
            throw new NotImplementedException();
        }
    }
}
