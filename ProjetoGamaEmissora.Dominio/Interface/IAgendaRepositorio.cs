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

        IEnumerable<Agenda> ConsultarAgendaProdutor(int idProdutor);

        IEnumerable<Agenda> ConsultarDatasMaisAgendadas(int idProdutor);

        IEnumerable<Agenda> ConsultarAtoresMaisReservados(int idProdutor);

    }
}
