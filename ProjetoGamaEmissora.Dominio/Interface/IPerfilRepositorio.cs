using ProjetoGamaEmissora.Dominio.Modelo;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Dominio.Interface
{
    public interface IPerfilRepositorio
    {
        Task<Perfil> RecuperarIdAsync(int id);
    }
}
