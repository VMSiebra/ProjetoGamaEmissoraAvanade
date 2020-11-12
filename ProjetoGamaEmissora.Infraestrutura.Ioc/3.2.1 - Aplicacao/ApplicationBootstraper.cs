using Microsoft.Extensions.DependencyInjection;
using ProjetoGamaEmissora.Application;
using ProjetoGamaEmissora.Application.AppAtor.Interfaces;


namespace ProjetoGamaEmissora.Infraestrutura.IoC._3._2._1___Aplicacao
{
    internal class ApplicationBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IAtorAppService, AtorAppService>();
        }
    }
}
