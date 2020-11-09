using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.Modelo
{
    public class Habilidade
    {
        public int _Id { get; private set; }
        public string _Descricao { get; private set; }

        public Habilidade(int id, string descricao)
        {
            _Id = id;
            _Descricao = descricao;
        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(_Descricao)) valid = false;

            return valid;
        }
    }
}
