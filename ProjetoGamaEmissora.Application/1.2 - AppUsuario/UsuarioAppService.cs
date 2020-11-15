using Marraia.Notifications.Interfaces;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._1___UsuarioInput;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._2___Interfaces;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._3___OutPut;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application._1._2___AppUsuario
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IPerfilRepositorio _perfilRepositorio;
        private readonly ISmartNotification _notification;

        public UsuarioAppService(ISmartNotification notification, IUsuarioRepositorio usuarioRepositorio, IPerfilRepositorio perfilRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _perfilRepositorio = perfilRepositorio;
            _notification = notification;
        }
        public async Task<UsuarioViewModel> InserirUsuarioAsync(UsuarioInput input)
        {
            var perfil = await _perfilRepositorio
                                    .RecuperarIdAsync(input._PerfilID)
                                    .ConfigureAwait(false);

            if (perfil is null)
            {
                _notification.NewNotificationBadRequest("O Perfil não existe!");
                return default;
            }

            var usuario = new Usuario(input._Name, input._Login, input._Senha, perfil);

            if (!usuario.IsValid())
            {
                _notification.NewNotificationBadRequest("Dados do usuário são obrigatórios");
                return default;
            }

            // Recuperar o id do usuário que foi inserido na base de dados.
            var id = await _usuarioRepositorio
                            .InserirUsuarioAsync(usuario)
                            .ConfigureAwait(false);

            // Com o ID recuperado no metodo acima iremos recupara o objeto usuario para colocar na tela os dados cadastrados
            return new UsuarioViewModel(id, usuario._Login, usuario._Name, usuario._Perfil, usuario._DataCriacao);
        }

        //public async Task<UserViewModel> UpdateAsync(int id, UserInput input)
        //{
        //    var user = await _userRepository
        //                            .GetByIdAsync(id)
        //                            .ConfigureAwait(false);

        //    if (user is null)
        //    {
        //        _notification.NewNotificationBadRequest("Usuário não encontrado");
        //        return default;
        //    }

        //    var profile = await _profileRepository
        //                            .GetByIdAsync(input.IdProfile)
        //                            .ConfigureAwait(false);

        //    if (profile is null)
        //    {
        //        _notification.NewNotificationBadRequest("Perfil associado não existe!");
        //        return default;
        //    }

        //    user.UpdateInfo(input.Name, input.Password, profile);

        //    await _userRepository
        //            .UpdateAsync(user)
        //            .ConfigureAwait(false);

        //    return new UserViewModel(id, user.Login, user.Name, user.Profile, user.Created);
        //}
    }
}
