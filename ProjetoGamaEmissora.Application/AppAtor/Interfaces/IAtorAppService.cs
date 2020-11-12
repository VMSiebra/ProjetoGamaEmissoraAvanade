using ProjetoGamaEmissora.Application.AppAtor.Input;
using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application.AppAtor.Interfaces
{
    public interface IAtorAppService
    {
        Task<Ator> InserirAtorAsync(AtorInput ator);
        Task<Ator> ConsultarItemAtorIdAsync(int id);
        IEnumerable<Ator> Get();
    }
}
