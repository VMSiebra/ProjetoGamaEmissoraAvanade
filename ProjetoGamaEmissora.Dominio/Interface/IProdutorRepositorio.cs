

using ProjetoGamaEmissora.Dominio.modelo;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Dominio.Interface
{
    public interface IProdutorRepositorio
    {
        Task<int> InserirProdutorAsync(Produtor agenda);

        Task<Produtor> ConsultarProdutorAsync(int id);

        Task<int> ConsultarProdutorUsuarioIdAsync(int UserId);

    }
}
