using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Dominio.Interface
{
    public interface IAtorRepositorio
    {
        Task<int> InserirAtorAsync(Ator agenda);

        Task<Ator> ConsultarItemAtorIdAsync(int id);

        IEnumerable<Ator> ConsultarAtores();
    }
}
