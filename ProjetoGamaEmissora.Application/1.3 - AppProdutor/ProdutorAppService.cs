using Marraia.Notifications.Interfaces;
using ProjetoGamaEmissora.Application._1._3___AppProdutor._1._3._1___ProdutorInput;
using ProjetoGamaEmissora.Application._1._3___AppProdutor._1._3._2___Interfaces;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application._1._3___AppProdutor
{
    public class ProdutorAppService : IProdutorAppService
    {
        private readonly IProdutorRepositorio _atorRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISmartNotification _notification;
        public ProdutorAppService(ISmartNotification notification,
                              IProdutorRepositorio atorRepositorio,
                              IUsuarioRepositorio usuarioRepositorio)
        {           
            _notification = notification;
            _usuarioRepositorio = usuarioRepositorio;
            _atorRepositorio = atorRepositorio;
        }

        public async Task<Produtor> ConsultarItemProdutorIdAsync(int id)
        {
            return await _atorRepositorio
                            .ConsultarItemProdutorIdAsync(id)
                            .ConfigureAwait(false);
        }

        public async Task<Produtor> InserirProdutorAsync(ProdutorInput input)
        {

            var user = await _usuarioRepositorio
                  .RecuperarIdAsync(input._UsuarioID)
                  .ConfigureAwait(false);
          

            if (user is null)
            {
                _notification.NewNotificationConflict("Usuário associado não existe!");
                return default;
            }

            var ator = new Produtor(user._UsuarioID, input._Nome);

            
            var actorId = await _produtorRepositorio
                            .ConsultarProdutorUsuarioIdAsync(user._UsuarioID)
                            .ConfigureAwait(false);

            if (actorId > 0)
            {
                _notification.NewNotificationConflict("Ator já cadastrado.");
                return default;
            }

            var atorId = await _produtorRepositorio
                   .InserirProdutorAsync(ator)
                   .ConfigureAwait(false);

            return await ConsultarItemProdutorIdAsync(atorId)
                            .ConfigureAwait(false);
        }
    }
}
