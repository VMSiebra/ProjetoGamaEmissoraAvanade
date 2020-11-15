using Marraia.Notifications.Interfaces;
using ProjetoGamaEmissora.Application.AppAtor.Input;
using ProjetoGamaEmissora.Application.AppAtor.Interfaces;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.modelo;
using ProjetoGamaEmissora.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application
{
    public class AtorAppService : IAtorAppService
    {
        private readonly IAtorRepositorio _atorRepositorio;
        private readonly ISmartNotification _notification;
        public AtorAppService(ISmartNotification notification, IAtorRepositorio atorRepositorio)
        {
            _notification = notification;
            _atorRepositorio = atorRepositorio;
        }

        public IEnumerable<Ator> ConsultarAtores()
        {
            return _atorRepositorio.ConsultarAtores();
        }

        public async Task<Ator> ConsultarItemAtorIdAsync(int id)
        {
            return await _atorRepositorio
                            .ConsultarItemAtorIdAsync(id)
                            .ConfigureAwait(false);
        }
        
        public async Task<Ator> InserirAtorAsync(AtorInput input)
        {
      
            var ator = new Ator(input._Nome,input._Idade,input._Sexo, input._Cache
                                ,input._Status, input._Relevancia);

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
