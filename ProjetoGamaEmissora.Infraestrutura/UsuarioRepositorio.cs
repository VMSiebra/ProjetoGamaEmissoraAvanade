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

        public async Task<Usuario> LoginAsync(string login)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var sqlCmd = @$"SELECT 
                                        U.UsuarioID,
	                                    U.Nome,
	                                    U.Login,
	                                    U.Senha,
	                                    P.PerfilID,
	                                    P.Descricao
                                    FROM 
	                                    USUARIO U JOIN PERFIL P
		                                    ON U.PerfilID = P.PerfilID      
                                    WHERE U.login='{login}'";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                        while (reader.Read())
                        {
                            var user = new Usuario(int.Parse(reader["UsuarioID"].ToString()),
                                                reader["Nome"].ToString(),
                                                new Perfil(int.Parse(reader["PerfilID"].ToString()),
                                                            reader["Descricao"].ToString()));

                            user.InformationLoginUser(reader["Login"].ToString(), reader["Senha"].ToString());
                            return user;
                        }

                        return default;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Usuario> RecuperarIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
