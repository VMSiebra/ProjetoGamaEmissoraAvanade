using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoGamaEmissora.Application._1._3___AppProdutor._1._3._1___ProdutorInput;
using ProjetoGamaEmissora.Application._1._3___AppProdutor._1._3._2___Interfaces;
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
    public class ProdutorController : BaseController
    {
        private readonly IProdutorAppService _produtorAppService;

        public ProdutorController(INotificationHandler<DomainNotification> notification,
                                IProdutorAppService heroAppService)
            : base(notification)
        {
            _produtorAppService = heroAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] ProdutorInput input)
        {
            var item = await _produtorAppService
                                .InserirProdutorAsync(input)
                                .ConfigureAwait(false);

            return CreatedContent("", item);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await _produtorAppService
                                 .ConsultarProdutorAsync(id)
                                 .ConfigureAwait(false);
            return Ok(item);
        }

    }
}
