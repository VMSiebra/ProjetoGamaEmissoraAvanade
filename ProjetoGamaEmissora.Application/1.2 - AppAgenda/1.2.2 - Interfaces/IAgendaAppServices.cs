using ProjetoGamaEmissora.Application._1._2___AppAgenda._1._2._1___AgendaInput;
using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Application._1._2___AppAgenda._1._2._2___Interfaces
{
    public interface IAgendaAppServices 
    {
        Task<int> InserirAgendaAsync(AgendaInput agenda);

        IEnumerable<Agenda> ConsultarAgendaProdutor(int idProdutor);

        IEnumerable<Agenda> ConsultarDatasMaisAgendadas(int idProdutor);

        IEnumerable<Agenda> ConsultarAtoresMaisReservados(int idProdutor);

    }
}
