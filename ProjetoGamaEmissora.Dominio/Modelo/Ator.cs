using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.modelo
{
    public class Ator : Funcionario
    {
        public List<Genero> _Genero { get; private set; }
        public List<Habilidade> _Habilidades { get; private set; }
        public double _Cache { get; private set; } 
        public bool _Status { get; private set; }
        public int _Relevancia { get; private set; }

        public Ator(string nome, int idade, string sexo, double cache, bool status, int relevancia)
           : base(nome, idade, sexo)
        {
            _Cache      = cache;
            _Status     = status;
            _Relevancia = relevancia;
        }

        public Ator(string nome, int idade, string sexo, List<Genero> genero, List<Habilidade> habilidades, double cache, bool status, int relevancia) 
            : base(nome, idade, sexo)
        {
            _Genero      = genero;
            _Habilidades = habilidades;
            _Cache       = cache;
            _Status      = status;
            _Relevancia  = relevancia;
        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(_Nome) || _Cache <= 0 ) valid = false;

            return valid;
        }

    }
}
