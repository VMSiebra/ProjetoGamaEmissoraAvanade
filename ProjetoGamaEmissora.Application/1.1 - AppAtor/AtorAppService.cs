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

        //Método somente o produtor acessa
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
      
            var ator = new Ator(input._UsuarioID, input._Nome, input._Idade, input._Sexo, input._Genero, input._Cache
                                ,input._Status, input._Relevancia);

            if (!ator.IsValid())
            {
                _notification.NewNotificationBadRequest("Os dados são obrigatórios");
                return default;
            }
            
            var id = await _atorRepositorio
                                .InserirAtorAsync(ator)
                                .ConfigureAwait(false);

            if ((!ator._Sexo.Equals("M")) || (!ator._Sexo.Equals("F")))
            {
                _notification.NewNotificationConflict("Informar o sexo como masculino ou feminino. ");
                return default;
            }

            if (ator._Cache <= 0)
            {
                _notification.NewNotificationConflict("Cachê inválido!");
                return default;
            }

            if (ator._Relevancia < 0 || ator._Relevancia > 5)
            {
                _notification.NewNotificationConflict("A relevância dever ser de 0 a 5 ");
                return default;
            }




            return await ConsultarItemAtorIdAsync(id)
                            .ConfigureAwait(false);
        }
    
}
}
