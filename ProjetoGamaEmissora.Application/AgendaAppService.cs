using Marraia.Notifications.Interfaces;
using ProjetoGamaEmissora.Application._1._2___AppAgenda._1._2._2___Interfaces;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

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
        public IEnumerable<Agenda> ConsultarAgendaProdutor()
        {
            return _agendaRepositorio.ConsultarAgendaProdutor();
        }

        public async Task<Ator> ConsultarItemAtorIdAsync(int id)
        {
            return await _atorRepositorio
                            .ConsultarItemAtorIdAsync(id)
                            .ConfigureAwait(false);
        }
        public int _AtorId { get; set; }
        public List<Genero> _Genero { get; set; }
        public double _Cache { get; set; }
        public bool _Status { get; set; }
        public int _Relevancia { get; set; }
        public async Task<Ator> InserirAtorAsync(AtorInput input)
        {

            var ator = new Ator(input._Nome, input._Idade, input._Sexo, input._Login, input._Senha, input._Cache
                                , input._Status, input._Relevancia);

            if (!ator.IsValid())
            {
                _notification.NewNotificationBadRequest("Os dados são obrigatórios");
                return default;
            }


            var id = await _atorRepositorio
                                .InserirAtorAsync(ator)
                                .ConfigureAwait(false);

            return await ConsultarItemAtorIdAsync(id)
                            .ConfigureAwait(false);
        }
    }
}
