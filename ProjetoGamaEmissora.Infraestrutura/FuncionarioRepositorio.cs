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
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        public Task<int> InserirAsync(Funcionario funcionario)
        {            
        }

        public IEnumerable<Funcionario> Consultar()
        {
            try
            {
                using (var con = new SqlConnection("")) 
                {
                    var funcionarioLista = new List<Funcionario>();
                    var comandoSQL = @"SELECT   
                                            F.Id, 
                                            F.Nome, 
                                            F.Idade, 
                                            F.Sexo, 
                                            F.Cache, 
                                            F.Status, 
                                            F.Relevancia
                                        FROM FUNCIONARIO F";

                    using (var cmd = new SqlCommand(comandoSQL, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            var ator = new Ator(
                                    reader["Nome"].ToString(),
                                    int.Parse(reader["Idade"].ToString()),
                                    reader["Sexo"].ToString(),
                                    double.Parse(reader["Cache"].ToString()),
                                    bool.Parse(reader["Status"].ToString()),
                                    int.Parse(reader["Relevancia"].ToString())
                                    );                                                          

                            funcionarioLista.Add(ator);
                        }

                        return funcionarioLista;
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
