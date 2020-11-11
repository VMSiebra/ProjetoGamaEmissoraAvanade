
using System.Collections.Generic;

namespace ProjetoGamaEmissora.Dominio.modelo
{

    public class Funcionario
    {
        public int _Id {get; private set;}
        public string _Nome {get; private set;}
        public int _Idade {get; private set;}         
        public string _Sexo { get; private set; }

        public string _Login { get; private set; }
        public string _Senha { get; private set; }

        public Funcionario(string nome, int idade, string sexo, string login, string senha)
        {            
            _Nome   = nome;
            _Idade  = idade;
            _Sexo   = sexo;
            _Login = login;
            _Senha = senha;
        }

        public Funcionario(int id, string nome, int idade,string sexo, string login, string senha)
        {
            _Id     = id;
            _Nome   = nome;
            _Idade  = idade;
            _Sexo   = sexo;
            _Login = login;
            _Senha = senha;
        }

        public virtual bool IsValid()
        {
            var valid = true;

            if (
                string.IsNullOrEmpty(_Nome) 
                ||  _Idade <= 0 
                || string.IsNullOrEmpty(_Sexo) 
                || string.IsNullOrEmpty(_Login)
                || string.IsNullOrEmpty(_Senha)                
                )  valid = false;

            return valid;
        }
    }
}
