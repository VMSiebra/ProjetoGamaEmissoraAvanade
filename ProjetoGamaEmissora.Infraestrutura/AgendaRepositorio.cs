using Microsoft.Extensions.Configuration;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.modelo;
using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Infraestrutura
{
    public class AgendaRepositorio : IAgendaRepositorio

    {
        

        private readonly IConfiguration _configuration;
        public AgendaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public  IEnumerable<Agenda> ConsultarAgendaProdutor(int idProdutor)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var agendaLista = new List<Agenda>();
                    var sqlCmd = @"SELECT AG.AgendaID, 
	                                   AG.ProdutorID, 
	                                   AG.AtorID, 
	                                   AG.DataInicio, 
	                                   AG.DataFim,
                                       A.AtorId,
                                       A.Nome NomeAtor,
                                       A.Idade,
                                       A.Sexo,
                                       A.Cache,
                                       A.Status,
                                       A.Relevancia,
                                       P.ProdutorId NomeProdutor,
                                       P.Nome
                                    FROM DBO.Agenda AG
                                  JOIN ATOR A ON A.AtorID = AG.AtorID
                                  JOIN PRODUTOR P ON P.ProdutorID = AG.ProdutorID
                                        WHERE AG.ProdutorID = @produtorId";
;
                    
                    using (var cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@produtorId", idProdutor);

                        con.Open();

                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            
                            var agenda = new Agenda(int.Parse(reader["AgendaID"].ToString())
                                                    , new Ator(int.Parse(reader["AtorId"].ToString())
                                                              , reader["NomeAtor"].ToString()
                                                              , int.Parse(reader["Idade"].ToString())
                                                              , char.Parse(reader["Sexo"].ToString())
                                                              , double.Parse(reader["Cache"].ToString())
                                                              , reader["Status"].ToString() 
                                                              , int.Parse(reader["Relevancia"].ToString()))
                                                    , new Produtor(int.Parse(reader["ProdutorId"].ToString()),
                                                                   reader["NomeProdutor"].ToString())                                                        
                                                    , DateTime.Parse(reader["DataInicio"].ToString())
                                                    , DateTime.Parse(reader["DataFim"].ToString()));

                            agendaLista.Add(agenda);
                        }

                        return agendaLista;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int>  InserirAgendaAsync(Agenda agenda) 
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var sqlCmd = @"INSERT INTO 
                                   DBO.AGENDA (ProdutorID, 
                                                AtorID, 
                                                DataInicio, 
                                                DataFim) 
                                   VALUES (@prodId, 
                                            @atorId,
                                            @dataIn, 
                                            @dataFim); SELECT scope_identity();";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("prodId", agenda._Produtor._ProdutorID);
                        cmd.Parameters.AddWithValue("atorId", agenda._Ator._AtorID);
                        cmd.Parameters.AddWithValue("dataIn", agenda._DataInicio);
                        cmd.Parameters.AddWithValue("dataFim",agenda._DataFim);

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
       
        public IEnumerable<Agenda> ConsultarDatasMaisAgendadas(int idProdutor)
        {
            return default;
        }

        public IEnumerable<Agenda> ConsultarAtoresMaisReservados(int idProdutor)
        {
            return default;
        }

       

    }
}
