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
        private readonly IProdutorRepositorio _produtorRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISmartNotification _notification;
        public ProdutorAppService(ISmartNotification notification,
                              IProdutorRepositorio produtorRepositorio,
                              IUsuarioRepositorio usuarioRepositorio)
        {           
            _notification = notification;
            _usuarioRepositorio = usuarioRepositorio;
            _produtorRepositorio = produtorRepositorio;
        }

        public async Task<Produtor> ConsultarProdutorAsync(int id)
        {
            return await _produtorRepositorio
                           .ConsultarProdutorAsync(id)
                           .ConfigureAwait(false);
        }

        public Task<int> ConsultarProdutorUsuarioIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Produtor> InserirProdutorAsync(ProdutorInput produtor)
        {
            var user = await _usuarioRepositorio
                  .RecuperarIdAsync(produtor._UsuarioID)
                  .ConfigureAwait(false);

        

            if (user is null)
            {
                _notification.NewNotificationConflict("Usuário associado não existe!");
                return default;
            }

            var ator = new Produtor(user._UsuarioID, produtor._Nome);

           

            var actorId = await _produtorRepositorio
                            .ConsultarProdutorUsuarioIdAsync(user._UsuarioID)
                            .ConfigureAwait(false);

            if (actorId > 0)
            {
                _notification.NewNotificationConflict("Produtor já cadastrado.");
                return default;
            }

            var produtorId = await _produtorRepositorio
                   .InserirProdutorAsync(ator)
                   .ConfigureAwait(false);

            return await ConsultarProdutorAsync(produtorId)
                            .ConfigureAwait(false);
        }
    }
}
