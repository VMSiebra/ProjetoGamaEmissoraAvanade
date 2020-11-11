using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Marraia.Notifications.Base;
using ProjetoGamaEmissora.Application.AppEmissora.Input;

namespace ProjetoGamaEmissora.Api.Controllers
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
            _heroAppService = heroAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] AtorInput input)
        {
            var item = await _heroAppService
                                .InsertAsync(input)
                                .ConfigureAwait(false);

            return CreatedContent("", item);
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            var item = _heroAppService.Get();
            return Ok(item);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var item = await _heroAppService
                                 .GetByIdAsync(id)
                                 .ConfigureAwait(false);
            return Ok(item);
        }
    }
}
