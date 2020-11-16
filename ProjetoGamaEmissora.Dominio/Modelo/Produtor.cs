using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Dominio.modelo
{
    public class Produtor
    {
        public int _ProdutorID { get; private set; }
        public int _UsuarioID { get; private set; }
        public string _Nome { get; private set; }
       


        public Produtor(int produtorId, int usuarioId, string nome)
        {
            _ProdutorID = produtorId;
            _UsuarioID = usuarioId;
            _Nome = nome;           
        }
        public Produtor(int usuarioId, string nome)
        {
            _UsuarioID = usuarioId;
            _Nome = nome;
        }

        public bool IsValid()
        {
            var valid = true;

            if (
                (string.IsNullOrEmpty(_Nome))               
               ) valid = false;

            return valid;
        }

    }
}
