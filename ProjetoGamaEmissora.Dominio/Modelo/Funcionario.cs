
using System.Collections.Generic;

namespace ProjetoGamaEmissora.Dominio.modelo
{

    public class Funcionario
    {
        public int _Id {get; private set;}
        public string _Nome {get; private set;}
        public int _Idade {get; private set;}         
        public string _Sexo { get; private set; }

        public Funcionario(string nome, int idade, string sexo)
        {            
            _Nome   = nome;
            _Idade  = idade;
            _Sexo   = sexo;
        }

        public Funcionario(int id, string nome, int idade,string sexo)
        {
            _Id     = id;
            _Nome   = nome;
            _Idade  = idade;
            _Sexo   = sexo;
        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(_Nome) ||  _Idade <= 0 || string.IsNullOrEmpty(_Sexo) )  valid = false;

            return valid;
        }
    }
}
