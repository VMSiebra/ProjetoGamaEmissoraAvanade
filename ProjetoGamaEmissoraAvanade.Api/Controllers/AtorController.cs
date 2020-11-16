using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoGamaEmissora.Application.AppAtor.Input;
using ProjetoGamaEmissora.Application.AppAtor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGamaEmissoraAvanade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtorController : BaseController
    {
        private readonly IAtorAppService _atorAppService;

        public AtorController(INotificationHandler<DomainNotification> notification,
                                IAtorAppService heroAppService)
            : base(notification)
        {
            _atorAppService = heroAppService;
        }
       
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] AtorInput input)
        {
            var item = await _atorAppService
                                .InserirAtorAsync(input)
                                .ConfigureAwait(false);

            return CreatedContent("", item);
        }

        //Só quem pode acessar a lista de atores eh o produtor!
        //Realizar a implementação
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            var item = _atorAppService.ConsultarAtores();
            return Ok(item);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await _atorAppService
                                 .ConsultarItemAtorIdAsync(id)
                                 .ConfigureAwait(false);
            return Ok(item);
        }
    }
}
