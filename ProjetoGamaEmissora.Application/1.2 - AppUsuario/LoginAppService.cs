using Marraia.Notifications.Interfaces;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._2___Interfaces;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._3___OutPut;
using ProjetoGamaEmissora.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application._1._2___AppUsuario
{
    public class LoginAppService : ILoginAppService
    {
        private readonly ISmartNotification _notification;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginAppService(ISmartNotification notification,
                                IUsuarioRepositorio usuarioRepository)
        {
            _notification = notification;
            _usuarioRepositorio = usuarioRepository;
        }

        public async Task<UsuarioViewModel> LoginAsync(string login, string senha)
        {
            var usuario = await _usuarioRepositorio
                                .PegarLoginAsync(login)
                                .ConfigureAwait(false);

            if (usuario == default)
            {
                _notification.NewNotificationBadRequest("Usuário não encontrado!");
                return default;
            }

            if (!usuario.IsEqualPassword(senha))
            {
                _notification.NewNotificationBadRequest("Senha incorreta!");
                return default;
            }

            return new UsuarioViewModel(usuario._UsuarioID, usuario._Login, usuario._Name, usuario._Perfil, usuario._DataCriacao);
        }
    }
}
