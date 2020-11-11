using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.modelo
{
    public class Produtor : Funcionario
    {
        public Produtor(string nome, int idade, string sexo, string login, string senha) : 
            base(nome, idade, sexo, login, senha)
        {
            
        }

    }
}
