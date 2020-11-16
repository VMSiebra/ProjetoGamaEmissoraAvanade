using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Dominio.Interface
{
    public class IProdutorRepositorio
    {
        Task<int> InserirProdutorAsync(Produtor agenda);
        Task<Produtor> ConsultarItemProdutorIdAsync(int id);
        Task<int> ConsultarProdutorUsuarioIdAsync(int UserId);
        IEnumerable<Produtor> ConsultarProdutores();
    }
}
