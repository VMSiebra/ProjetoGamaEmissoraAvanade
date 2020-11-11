using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.Modelo
{
    public class Agenda
    {

        public int _AgendaId { get; private set; }
        public Ator _Ator { get; private set; }
        public Produtor _Produtor { get; private set; }
        public DateTime _Data { get; private set; }

        public Agenda()
        {

        }

        public Agenda(int agendaId, Ator ator, Produtor produtor, DateTime data )
        {
            _AgendaId = agendaId;
            _Ator     = ator;
            _Produtor = produtor;
            _Data     = data;
        }

        public bool IsValid()
        {
            var valid = true;

            if (_Data == null || _Ator._Id <= 0 || _Produtor._Id <= 0)
            {
                valid = false;
            }

            return valid;
        }




    }
}
