using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.modelo
{
    public class Ator
    {
        public int _AtorID { get; private set; }
        public int _UsuarioID { get; private set; }
        public string _Nome { get; private set; }
        public int _Idade { get; private set; }
        public string _Sexo { get; private set; }
        public List<Genero> _Genero { get; private set; }
        public double _Cache { get; private set; } 
        public string _Status { get; private set; }
        public int _Relevancia { get; private set; }

        public Ator(int atorId, string nome, int idade, string sexo, double cache, string status, int relevancia)           
        {
            _AtorID     = atorId;
            _Nome       = nome;
            _Idade      = idade;
            _Sexo       = sexo;
            _Cache      = cache;
            _Status     = status;
            _Relevancia = relevancia;
        }

        public Ator(string nome, int idade, string sexo, double cache, string status, int relevancia)
        {
            _Nome = nome;
            _Idade = idade;
            _Sexo = sexo;
            _Cache = cache;
            _Status = status;
            _Relevancia = relevancia;
        }

        public Ator(string nome, int idade, string sexo, List<Genero> genero, double cache,
            string status, int relevancia)            
        {
            _Nome = nome;
            _Idade = idade;
            _Sexo = sexo;
            _Cache = cache;
            _Status = status;
            _Relevancia = relevancia;
        }

        public Ator(int usuarioId, int atorId, string nome, int idade, string sexo, List<Genero> genero, double cache,
            string status, int relevancia)
        {
            _AtorID = atorId;
            _UsuarioID = usuarioId;
            _Nome = nome;
            _Idade = idade;
            _Sexo = sexo;
            _Cache = cache;
            _Status = status;
            _Relevancia = relevancia;
        }

        public bool IsValid()
        {
            var valid = true;

            if (
                (string.IsNullOrEmpty(_Nome)) || 
                (_Idade <= 0) || 
                (string.IsNullOrEmpty(_Sexo)) || 
                (_Cache <= 0)
               ) valid = false;

            return valid;
        }

    }
}
