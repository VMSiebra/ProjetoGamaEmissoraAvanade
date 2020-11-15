using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.Modelo
{
    public class Perfil
    {
        public int _PerfilID { get; private set; }
        public string _Descricao { get; private set; }
        
        public Perfil(string descricao)
        {
            _Descricao = descricao;
        }

        public Perfil(int id, string descricao)
        {
            _PerfilID  = id;
            _Descricao = descricao;
        }

    }
}
