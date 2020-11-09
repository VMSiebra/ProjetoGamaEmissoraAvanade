using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Dominio.Interface
{
    public interface IFuncionarioRepositorio
    {
        Task<int> InserirAsync(Funcionario funcionario);
        //Task<Hero> GetByIdAsync(int id);
        IEnumerable<Funcionario> Consultar();
    }
}
