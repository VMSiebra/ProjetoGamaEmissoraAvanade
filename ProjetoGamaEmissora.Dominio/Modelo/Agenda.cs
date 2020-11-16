using ProjetoGamaEmissora.Dominio.modelo;
using System;


namespace ProjetoGamaEmissora.Dominio.Modelo
{
    public class Agenda
    {

        public int _AgendaId { get; private set; }
        public Ator _Ator { get; private set; }
        public Produtor _Produtor { get; private set; }
        public DateTime _DataInicio { get; private set; }
        public DateTime _DataFim { get; private set; }

        public Agenda()
        {

        }

        public Agenda(Ator ator, Produtor produtor, DateTime dataInicio, DateTime dataFim)
        {
            _Ator = ator;
            _Produtor = produtor;
            _DataInicio = dataInicio;
            _DataFim = dataFim;
        }

        public Agenda(int agendaId, Ator ator, Produtor produtor, DateTime dataInicio, DateTime dataFim)
        {
            _AgendaId = agendaId;
            _Ator = ator;
            _Produtor = produtor;
            _DataInicio = dataInicio;
            _DataFim = dataFim;
        }

        public bool IsValid()
        {
            var valid = true;

            if (_DataInicio == null || _DataFim == null || _Ator._AtorID <= 0 || _Produtor._ProdutorID <= 0)
            {
                valid = false;
            }

            return valid;
        }




    }
}