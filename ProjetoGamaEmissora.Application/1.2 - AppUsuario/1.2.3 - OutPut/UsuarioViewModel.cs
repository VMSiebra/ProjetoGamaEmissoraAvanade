using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoGamaEmissora.Application._1._2___AppUsuario._1._2._3___OutPut
{
    public class UsuarioViewModel
    {

        //Classe usada para representar o usuario no retorno sem a senha!

        public int _Id { get; set; }
        public string _Login { get; set; }
        public string _Name { get; set; }
        public Perfil _Perfil { get; set; }
        public DateTime _DataCriacao { get; set; }

        public UsuarioViewModel(int id, string login, string name, Perfil perfil, DateTime dataCriacao)
        {
            _Id = id;
            _Login = login;
            _Name = name;
            _Perfil = perfil;
            _DataCriacao = dataCriacao;
        }

    }
}
