using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._1___UsuarioInput;
using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._3___OutPut;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._2___Interfaces
{
    public interface IUsuarioAppService
    {
        Task<UsuarioViewModel> InserirUsuarioAsync(UsuarioInput user);
        //Task<UsuarioViewModel> UpdateAsync(int id, UsuarioInput user);
    }
}
