using Microsoft.Extensions.DependencyInjection;
using ProjetoGamaEmissora.Infraestrutura.IoC._3._2._1___Aplicacao;
using ProjetoGamaEmissora.Infraestrutura.IoC._3._2._2___Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Infraestrutura.Ioc
{
    public class RootBootstraper
    {
        public void RootRegisterServices(IServiceCollection services)
        {
            new ApplicationBootstraper().ChildServiceRegister(services);
            new RepositorioBootstraper().ChildServiceRegister(services);
        }
    }
}
