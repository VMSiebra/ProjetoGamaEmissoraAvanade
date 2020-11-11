using Marraia.Notifications.Base;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IHeroAppService _heroAppService;

        public HeroController(INotificationHandler<DomainNotification> notification,
                                IHeroAppService heroAppService)
            : base(notification)
        {
            _heroAppService = heroAppService;
        }

    }
}
