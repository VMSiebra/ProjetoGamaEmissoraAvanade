using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Dominio.Interface
{
    public interface IAgendaRepositorio
    {
        Task<int> InserirAgendaAsync(Agenda agenda);

        Task<Agenda> ConsultarItemAgendaIdAsync(int id);

        IEnumerable<Agenda> ConsultarAgenda();
    }
}
