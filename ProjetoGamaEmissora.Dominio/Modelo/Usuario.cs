using ProjetoGamaEmissora.Dominio.Core;
using System;

namespace ProjetoGamaEmissora.Dominio.Modelo
{
    public class Usuario
    {

        public int _UsuarioID { get; private set; }
        public string _Login { get; private set; }
        public string _Name { get; private set; }
        public string _Senha { get; private set; }
        public Perfil _Perfil { get; private set; }
        public DateTime _DataCriacao { get; set; }

        public Usuario(string name, string login, string senha, Perfil profile)
        {
            _Name       = name;
            _Login      = login;
            CriptografyPassword(senha);
            _Perfil = profile;
            _DataCriacao = DateTime.Now;
        }

        public Usuario(int id, string name, Perfil perfil)
        {
            _UsuarioID = id;
            _Name = name;
            _Perfil = perfil;
        }

        public bool IsValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(_Name) ||
                string.IsNullOrEmpty(_Login) ||
                string.IsNullOrEmpty(_Senha) ||
                    _Perfil._PerfilID <= 0)
            {
                valid = false;
            }

            return valid;
        }

        public void CriptografyPassword(string senha)
        {
            _Senha = GerarSenha.Hash(senha);
        }

        public bool IsEqualPassword(string senha)
        {
            return GerarSenha.Verify(senha, _Senha);
        }

        public void InformationLoginUser(string login, string senha)
        {
            _Login = login;
            _Senha = senha;
        }

        public void SetId(int id)
        {
            _UsuarioID = id;
        }

        public void UpdateInfo(string name,
                    string senha,
                    Perfil perfil)
        {
            _Name = name;
            _Perfil = perfil;

            if (senha != _Senha)
                CriptografyPassword(senha);
        }
    }
}
