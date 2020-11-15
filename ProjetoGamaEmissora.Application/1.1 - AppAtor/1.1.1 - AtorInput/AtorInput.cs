using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Application.AppAtor.Input
{
    public class AtorInput
    {   
        public string _Nome { get; set; }
        public int _Idade { get; set; }
        public string _Sexo { get; set; }        
        public List<Genero> _Genero { get; set; }
        public double _Cache { get; set; }
        public string _Status { get; set; }
        public int _Relevancia { get; set; }     
    }
}
