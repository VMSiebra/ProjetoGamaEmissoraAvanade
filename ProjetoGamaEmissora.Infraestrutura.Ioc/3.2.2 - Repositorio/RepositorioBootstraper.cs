using Microsoft.Extensions.DependencyInjection;
using ProjetoGamaEmissora.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Infraestrutura.IoC._3._2._2___Repositorio
{
    internal class RepositorioBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IAtorRepositorio, AtorRepositorio>();
        }
    }
}
