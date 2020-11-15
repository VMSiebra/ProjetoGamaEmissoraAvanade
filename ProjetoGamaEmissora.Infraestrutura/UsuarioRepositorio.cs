using Microsoft.Extensions.Configuration;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.Modelo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Infraestrutura
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly IConfiguration _configuration;
        public UsuarioRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }
               
        public async Task<int> InserirUsuarioAsync(Usuario user)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var sqlCmd = @"INSERT INTO 
                                    USUARIO (PerfilID,
                                            Nome, 
                                            Login, 
                                            Senha, 
                                            DataCriacao) 
                               VALUES (@PerfilID, 
                                        @Nome,
                                        @Login, 
                                        @Senha,
                                        @DataCriacao); SELECT scope_identity();";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("PerfilID", user._Perfil._PerfilID);
                        cmd.Parameters.AddWithValue("Nome", user._Name);
                        cmd.Parameters.AddWithValue("Login", user._Login);
                        cmd.Parameters.AddWithValue("Senha", user._Senha);
                        cmd.Parameters.AddWithValue("DataCriacao", user._DataCriacao);

                        con.Open();
                        var id = await cmd
                                       .ExecuteScalarAsync()
                                       .ConfigureAwait(false);

                        return int.Parse(id.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }       

        public Task ALterarUsuarioAsync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> PegarLoginAsync(string login)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> RecuperarIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
