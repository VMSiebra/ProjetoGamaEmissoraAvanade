using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._1___UsuarioInput;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._2___Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGamaEmissoraAvanade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(INotificationHandler<DomainNotification> notification,
                               IUsuarioAppService usuarioAppService)
            : base(notification)
        {
            _usuarioAppService = usuarioAppService;
        }

       // [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] UsuarioInput input)
        {
            var usuario = await _usuarioAppService
                                .InserirUsuarioAsync(input)
                                .ConfigureAwait(false);

            return CreatedContent("", usuario);
        }
    }
}
