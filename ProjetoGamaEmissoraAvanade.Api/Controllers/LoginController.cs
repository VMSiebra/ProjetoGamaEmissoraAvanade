﻿using Marraia.Notifications.Base;
using Marraia.Notifications.Handlers;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._1___UsuarioInput;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._2___Interfaces;
using ProjetoGamaEmissoraAvanade.Api.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ProjetoGamaEmissoraAvanade.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly ILoginAppService _loginAppService;
        private readonly IConfiguration _configuration;
        private readonly DomainNotificationHandler _smartNotification;

        public LoginController(INotificationHandler<DomainNotification> notification, ILoginAppService loginAppService, IConfiguration configuration)
            : base(notification)
        {
            _loginAppService = loginAppService;
            _configuration = configuration;
            _smartNotification = (DomainNotificationHandler)notification;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(string), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<object> Post([FromBody] LoginInput input,
                                        [FromServices] SigningConfigurations signingConfigurations)
        {
            try
            {
                var logged = await _loginAppService
                                    .LoginAsync(input.Login, input.Senha)
                                    .ConfigureAwait(false);

                if (logged != default)
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(logged._Login, "Login"),
                        new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, logged._Id.ToString()),
                        new Claim(ClaimTypes.Role, logged._Perfil._Descricao),
                        new Claim("PerfilID", logged._Perfil._PerfilID.ToString()),
                        new Claim("Nome", logged._Name)
                        }
                    );

                    var dateCreated = DateTime.Now;
                    var dateExpiration = dateCreated + TimeSpan.FromSeconds(int.Parse(_configuration["TokenSeconds"]));

                    var handler = new JwtSecurityTokenHandler();
                    var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                    {
                        Issuer = _configuration["TokenIssuer"],
                        Audience = _configuration["TokenAudience"],
                        SigningCredentials = signingConfigurations.SigningCredentials,
                        Subject = identity,
                        NotBefore = dateCreated,
                        Expires = dateExpiration
                    });
                    var token = handler.WriteToken(securityToken);

                    return new
                    {
                        authenticated = true,
                        created = dateCreated.ToString("yyyy-MM-dd HH:mm:ss"),
                        expiration = dateExpiration.ToString("yyyy-MM-dd HH:mm:ss"),
                        accessToken = token,
                        message = "OK"
                    };
                }


                return Unauthorized(_smartNotification.GetNotifications());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + " " + ex.InnerException);
            }
        }
    }
}
