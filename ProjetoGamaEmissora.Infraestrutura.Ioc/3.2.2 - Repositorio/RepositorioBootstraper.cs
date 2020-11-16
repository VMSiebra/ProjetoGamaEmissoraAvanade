using Microsoft.Extensions.DependencyInjection;
using ProjetoGamaEmissora.Application._1._2___AppUsuario;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._2___Interfaces;
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
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IPerfilRepositorio, PerfilRepositorio>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IAtorRepositorio, AtorRepositorio>();
            services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();
        }
    }
}
