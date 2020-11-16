using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Dominio.Interface
{
    public interface IGeneroRepositorio
    {
        Task<List<Genero>> GetGeneroIdAsync(List<int> id);
    }
}
