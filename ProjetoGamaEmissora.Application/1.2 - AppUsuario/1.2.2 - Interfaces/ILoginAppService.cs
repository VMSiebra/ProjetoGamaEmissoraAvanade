using ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._3___OutPut;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._2___Interfaces
{
    public interface ILoginAppService
    {        
        Task<UsuarioViewModel> LoginAsync(string login, string senha);
    }
}
