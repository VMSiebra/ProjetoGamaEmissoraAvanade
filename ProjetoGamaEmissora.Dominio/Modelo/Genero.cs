using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.modelo
{
    public class Genero
    {
        public int _Id { get; private set; }
        public string _Descricao { get; private set; }

        public Genero(int id, string descricao)
        {
            _Id     = id;
            _Descricao = descricao;
        }

        
    }
}
