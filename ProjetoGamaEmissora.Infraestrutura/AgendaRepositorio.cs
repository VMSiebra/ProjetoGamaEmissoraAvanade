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
    public class AgendaRepositorio : IAgendaRepositorio

    {
        

        private readonly IConfiguration _configuration;
        public AgendaRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Agenda> ConsultarAgendaProdutorAsync(int idProdutor)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var agendaLista = new List<Agenda>();
                    var sqlCmd = @"SELECT AgendaID, 
	                                   ProdutorID, 
	                                   AtorID, 
	                                   DataInicio, 
	                                   DataFim
                                    FROM DBO.Agenda
                                        WHERE ProdutorID = @produtorId";
;

                    using (var cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@produtorId", idProdutor);

                        con.Open();

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                        while (reader.Read())
                        {
                            var agenda = new Agenda(int.Parse(reader["AgendaID"].ToString()));

                            return agenda;
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

        Task<Agenda> InserirAgendaAsync(Agenda agenda) 
        {
            throw new NotImplementedException();
        }

        Task<Agenda> ConsultarDatasMaisAgendadasAsync(int idProdutor)
        {
            throw new NotImplementedException();
        }

        Task<Agenda> ConsultarAtoresMaisReservadosAsync(int idProdutor)
        {
            throw new NotImplementedException();
        }
    }
}
