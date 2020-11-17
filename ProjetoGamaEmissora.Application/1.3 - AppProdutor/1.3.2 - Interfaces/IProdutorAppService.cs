using ProjetoGamaEmissora.Application._1._3___AppProdutor._1._3._1___ProdutorInput;
using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application._1._3___AppProdutor._1._3._2___Interfaces
{
    public interface IProdutorAppService 
    {
        Task<Produtor> InserirProdutorAsync(ProdutorInput produtor);
        Task<Produtor> ConsultarProdutorAsync(int id);       
        Task<int> ConsultarProdutorUsuarioIdAsync(int id);       
    }
}
