using ProjetoGamaEmissora.Application.AppEmissora.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoGamaEmissora.Application.AppEmissora.Interfaces
{
    public interface IAtorAppService
    {
        Task<Ator> InsertAsync(AtorInput ator);
        Task<Ator> GetByIdAsync(int id);
        IEnumerable<Ator> Get();
    }
}
