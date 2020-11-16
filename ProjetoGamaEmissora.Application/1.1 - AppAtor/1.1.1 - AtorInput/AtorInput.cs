using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Application.AppAtor.Input
{
    public class AtorInput
    {
        public int _UsuarioID { get; set; }
        public string _Nome { get; set; }
        public int _Idade { get; set; }
        public char _Sexo { get; set; }        
        public List<int> _Genero { get; set; }
        public double _Cache { get; set; }
        public string _Status { get; set; }
        public int _Relevancia { get; set; }     
    }
}
