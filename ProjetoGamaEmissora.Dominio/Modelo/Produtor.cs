using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.modelo
{
    public class Produtor
    {
        public int _UsuarioID { get; private set; }
        public string _Nome { get; private set; }
        public int _Idade { get; private set; }
        public string _Sexo { get; private set; }       

        public Produtor(string nome, int idade, string sexo)
        {
            _Nome = nome;
            _Idade = idade;
            _Sexo = sexo;
        }

        public Produtor(int usuarioId, string nome, int idade, string sexo)
        {
            _UsuarioID = usuarioId;
            _Nome = nome;
            _Idade = idade;
            _Sexo = sexo;
        }

        public bool IsValid()
        {
            var valid = true;

            if (
                (string.IsNullOrEmpty(_Nome)) ||
                (_Idade <= 0) ||
                (string.IsNullOrEmpty(_Sexo))               
               ) valid = false;

            return valid;
        }

    }
}
