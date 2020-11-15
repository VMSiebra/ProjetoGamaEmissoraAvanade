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
        Task<Agenda> InserirAgendaAsync(Agenda agenda);

        Task<Agenda> ConsultarAgendaProdutorAsync(int idProdutor);

        Task<Agenda> ConsultarDatasMaisAgendadasAsync(int idProdutor);

        Task<Agenda> ConsultarAtoresMaisReservadosAsync(int idProdutor);

    }
}
