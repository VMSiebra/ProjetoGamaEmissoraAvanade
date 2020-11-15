using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Dominio.Interface
{
    public interface IAgendaRepositorio
    {
        Task<Agenda> InserirAgendaAsync(Agenda agenda);

        Task<Agenda> ConsultarAgendaProdutorAsync(int idProdutor);

        Task<Agenda> ConsultarDatasMaisAgendadasAsync(int idProdutor);

        Task<Agenda> ConsultarAtoresMaisReservadosAsync(int idProdutor);

    }
}
