using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoGamaEmissora.Application._1._2___AppAgenda._1._2._2___Interfaces;
using ProjetoGamaEmissora.Dominio.Modelo;
using System.Threading.Tasks;

namespace ProjetoGamaEmissoraAvanade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : BaseController
    {
        private readonly IAgendaAppServices _agendaAppService;

        public AgendaController(INotificationHandler<DomainNotification> notification,
                                IAgendaAppServices agendaAppService)
            : base(notification)
        {
            _agendaAppService = agendaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] Agenda input)
        {
            var item = await _agendaAppService
                                .InserirAgendaAsync(input)
                                .ConfigureAwait(false);

            return CreatedContent("", item);
        }


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult>  Get([FromRoute] int id)
        {
            var item = await _agendaAppService
                                 .ConsultarAgendaProdutorAsync(id)
                                 .ConfigureAwait(false);
            return Ok(item);
        }

       // Task<Agenda> ConsultarDatasMaisAgendadasAsync(int idProdutor);

       // Task<Agenda> ConsultarAtoresMaisReservadosAsync(int idProdutor);
    }
}
