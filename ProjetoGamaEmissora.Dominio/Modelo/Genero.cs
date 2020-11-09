using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.modelo
{
    public class Genero
    {
        public int _Id { get; private set; }
        public string _Genero { get; private set; }

        public Genero(int id, string genero)
        {
            _Id     = id;
            _Genero = genero;
        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(_Genero)) valid = false;

            return valid;
        }
    }
}
