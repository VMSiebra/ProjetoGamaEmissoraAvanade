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
        private readonly IGeneroRepositorio _generoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISmartNotification _notification;
        public AtorAppService(ISmartNotification notification, 
                              IAtorRepositorio atorRepositorio,
                              IUsuarioRepositorio usuarioRepositorio,
                              IGeneroRepositorio generoRepositorio)
        {
            _generoRepositorio = generoRepositorio;
            _notification = notification;
            _usuarioRepositorio = usuarioRepositorio;
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

            var user = await _usuarioRepositorio
                  .RecuperarIdAsync(input._UsuarioID)
                  .ConfigureAwait(false);

            var genero = await _generoRepositorio
                .GetGeneroIdAsync(input._Genero)
                .ConfigureAwait(false);

            if (user is null)
            {
                _notification.NewNotificationConflict("Usuário associado não existe!");
                return default;
            }

            var ator = new Ator(user._UsuarioID, input._Nome, input._Idade, input._Sexo, genero, input._Cache
                                ,input._Status, input._Relevancia);

            if (!ator.IsValid())
            {
                _notification.NewNotificationConflict("Os dados são obrigatórios");
                return default;
            }

            if ((ator._Sexo != 'M') && (ator._Sexo != 'F'))
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

            var actorId = await _atorRepositorio
                            .ConsultarAtorUsuarioIdAsync(user._UsuarioID)
                            .ConfigureAwait(false);

            if (actorId > 0)
            {
                _notification.NewNotificationConflict("Ator já cadastrado.");
                return default;
            }

            var atorId = await _atorRepositorio
                   .InserirAtorAsync(ator)
                   .ConfigureAwait(false);

            return await ConsultarItemAtorIdAsync(atorId)
                            .ConfigureAwait(false);
        }
    
}
}
