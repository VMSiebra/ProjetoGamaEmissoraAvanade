using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.modelo
{
    public class Ator : Funcionario
    {
        public List<Genero> _Genero { get; private set; }
        public double _Cache { get; private set; } 
        public bool _Status { get; private set; }
        public int _Relevancia { get; private set; }

        public Ator(string nome, int idade, string sexo, string login, string senha, double cache, bool status, int relevancia)
           : base(nome, idade, sexo, login, senha)
        {
            _Cache      = cache;
            _Status     = status;
            _Relevancia = relevancia;
        }

        public Ator(string nome, int idade, string sexo, string login, string senha, List<Genero> genero, double cache, 
            bool status, int relevancia) 
            : base(nome, idade, sexo, login, senha)
        {
            _Genero      = genero;
            _Cache       = cache;
            _Status      = status;
            _Relevancia  = relevancia;
        }

        public override bool IsValid()
        {
            var valid = true;


            if (
                (string.IsNullOrEmpty(_Nome)) || 
                (_Idade <= 0) || 
                (string.IsNullOrEmpty(_Sexo)) || 
                (string.IsNullOrEmpty(_Nome)) || 
                (_Cache <= 0)
               ) valid = false;

            return valid;
        }

    }
}
