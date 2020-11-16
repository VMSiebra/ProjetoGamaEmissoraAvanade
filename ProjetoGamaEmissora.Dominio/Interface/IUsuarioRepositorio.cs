using ProjetoGamaEmissora.Dominio.Modelo;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Dominio.Interface
{
    public interface IUsuarioRepositorio
    {
        Task<int> InserirUsuarioAsync(Usuario usuario);
        Task ALterarUsuarioAsync(Usuario usuario);
        Task<Usuario> LoginAsync(string login);
        Task<Usuario> RecuperarIdAsync(int id);
    }
}
