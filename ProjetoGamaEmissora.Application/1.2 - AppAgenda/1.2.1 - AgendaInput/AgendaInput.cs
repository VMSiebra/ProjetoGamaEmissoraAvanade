using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Application._1._2___AppAgenda._1._2._1___AgendaInput
{
    public class AgendaInput
    {
        public int _UsuarioID { get; set; }
        public int _AgendaId { get; private set; }
        public int _AtorId { get; private set; }
        public string _AtorNome { get; set; }
        public int _AtorIdade { get; set; }
        public char _AtorSexo { get; set; }
        public double _AtorCache { get; set; }
        public string _AtorStatus { get; set; }
        public int _AtorRelevancia { get; set; }
        public int _ProdutorId { get; private set; }
        public string _ProdutorNome { get; private set; }
        public DateTime _DataInicio { get; private set; }
        public DateTime _DataFim { get; private set; }

        

    }
}
