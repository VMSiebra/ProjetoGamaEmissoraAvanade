using Marraia.Notifications.Interfaces;
using ProjetoGamaEmissora.Application._1._2___AppAgenda._1._2._1___AgendaInput;
using ProjetoGamaEmissora.Application._1._2___AppAgenda._1._2._2___Interfaces;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.modelo;
using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application
{
    public class AgendaAppService : IAgendaAppServices
    {
        private readonly IAgendaRepositorio _agendaRepositorio;
        private readonly ISmartNotification _notification;
        public AgendaAppService(ISmartNotification notification,
                                IAgendaRepositorio agendaRepositorio)
        {
            _notification = notification;
            _agendaRepositorio = agendaRepositorio;
        }

        public int _AtorId { get; set; }
        public List<Genero> _Genero { get; set; }
        public double _Cache { get; set; }
        public bool _Status { get; set; }
        public int _Relevancia { get; set; }

        public IEnumerable<Agenda> ConsultarAgendaProdutor(int id)
        {
            return _agendaRepositorio.ConsultarAgendaProdutor(id);
        }

        public async Task<int> InserirAgendaAsync(AgendaInput input)
        {

            var agenda = new Agenda(new Ator(input._AtorId, input._AtorNome, input._AtorIdade, input._AtorSexo, input._AtorCache, input._AtorStatus, input._AtorRelevancia)
                                    , new Produtor(input._ProdutorId, input._ProdutorNome)
                                    , input._DataInicio, input._DataFim);

            if (!agenda.IsValid())
            {
                _notification.NewNotificationBadRequest("Os dados são obrigatórios");
                
            }


            var id = await _agendaRepositorio
                                .InserirAgendaAsync(agenda)
                                .ConfigureAwait(false);
            
            return id;

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
