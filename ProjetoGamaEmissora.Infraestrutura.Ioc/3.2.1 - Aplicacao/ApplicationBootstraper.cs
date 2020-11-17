using Microsoft.Extensions.DependencyInjection;
using ProjetoGamaEmissora.Application;
using ProjetoGamaEmissora.Application._1._2___AppAgenda._1._2._2___Interfaces;
using ProjetoGamaEmissora.Application._1._2___AppUsuario;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._2___Interfaces;
using ProjetoGamaEmissora.Application._1._3___AppProdutor;
using ProjetoGamaEmissora.Application._1._3___AppProdutor._1._3._2___Interfaces;
using ProjetoGamaEmissora.Application.AppAtor.Interfaces;

namespace ProjetoGamaEmissora.Infraestrutura.IoC._3._2._1___Aplicacao
{
    internal class ApplicationBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IAtorAppService, AtorAppService>();
            services.AddScoped<IProdutorAppService, ProdutorAppService>();
            services.AddScoped<IAgendaAppServices, AgendaAppService>();
        }
    }
}
