using Microsoft.Extensions.Configuration;
using ProjetoGamaEmissora.Dominio.Interface;
using ProjetoGamaEmissora.Dominio.modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGamaEmissora.Infraestrutura
{
    public class AtorRepositorio : IAtorRepositorio
    {
        private readonly IConfiguration _Configuration;

        public AtorRepositorio(IConfiguration config)
        {
            _Configuration = config; 
        }

        //Só quem tem permissão de consultar eh o produtor!!!!!!!!!!!!
        public IEnumerable<Ator> ConsultarAtores()
        {
            try
            {
                using (var con = new SqlConnection(_Configuration["ConnectionString"]))
                {
                    var atorLista = new List<Ator>();
                    var comandoSQL = @"SELECT
                                        A.UsuarioID,
                                        A.AtorID,
                                        A.Nome, 
                                        A.Idade, 
                                        A.Sexo, 
                                        A.Cache, 
                                        A.Status, 
                                        A.Relevancia
                                    FROM ATOR A";

                    using (var cmd = new SqlCommand(comandoSQL, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = cmd.ExecuteReader();

                        

                        while (reader.Read())
                        {
                            var generoLista = new List<Genero>();

                            var comandoSQLGenero = @"SELECT 
                                                        G.GeneroID,
                                                        G.Descricao
                                                    FROM AtorGenero AG INNER JOIN Genero G 
                                                        ON AG.GeneroID = G.GeneroID
                                                    WHERE AG.AtorID = @AtorID";

                            using (var con2 = new SqlConnection(_Configuration["ConnectionString"]))
                            {
                                con2.Open();
                                using (var cmdGenero = new SqlCommand(comandoSQLGenero, con2))
                                {
                                    cmdGenero.CommandType = CommandType.Text;
                                    cmdGenero.Parameters.AddWithValue("@AtorID", reader["AtorId"].ToString());

                                    var readerGenero = cmdGenero.ExecuteReader();

                                    while (readerGenero.Read())
                                    {
                                        var genero = new Genero(int.Parse(readerGenero["GeneroID"].ToString()),
                                            readerGenero["Descricao"].ToString());
                                        generoLista.Add(genero);
                                    }

                                }
                            }

                            var ator = new Ator(
                                            int.Parse(reader["UsuarioID"].ToString()),
                                            int.Parse(reader["AtorID"].ToString()),
                                            reader["Nome"].ToString(),
                                            int.Parse(reader["Idade"].ToString()),
                                            char.Parse(reader["Sexo"].ToString()),                                            
                                            generoLista,
                                            double.Parse(reader["Cache"].ToString()),
                                            reader["Status"].ToString(),
                                            int.Parse(reader["Relevancia"].ToString())
                                        );

                            atorLista.Add(ator);
                        }

                        return atorLista;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> ConsultarAtorUsuarioIdAsync(int UserId)
        {
            try
            {
                using (var con = new SqlConnection(_Configuration["ConnectionString"]))
                {
                    con.Open();


                    var sqlCmd = @"SELECT
                                    A.UsuarioID,
                                    A.AtorID,
                                    A.Nome, 
                                    A.Idade, 
                                    A.Sexo, 
                                    A.Cache, 
                                    A.Status, 
                                    A.Relevancia
                                FROM ATOR A
                                    WHERE A.[UsuarioID] = @Id";

                    using (var cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", UserId);

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                        if (reader.Read())
                        {
                            return int.Parse(reader["UsuarioID"].ToString());
                        }

                        return 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Ator> ConsultarItemAtorIdAsync(int id)
        {
            try
            {
                using (var con = new SqlConnection(_Configuration["ConnectionString"]))
                {
                    con.Open();


                    var sqlCmd = @"SELECT
                                    A.UsuarioID,
                                    A.AtorID,
                                    A.Nome, 
                                    A.Idade, 
                                    A.Sexo, 
                                    A.Cache, 
                                    A.Status, 
                                    A.Relevancia
                                FROM ATOR A
                                    WHERE A.[AtorID] = @Id";

                    using (var cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                        while (reader.Read())
                        {
                            var generos = new List<Genero>();

                            var sqlGenres = @"SELECT G.GeneroID,
                                                        G.Descricao
                                                    FROM AtorGenero AG INNER JOIN Genero G 
                                                        ON AG.GeneroID = G.GeneroID
                                                    WHERE AG.AtorID = @AtorID";

                            using (var con2 = new SqlConnection(_Configuration["ConnectionString"]))
                            {
                                con2.Open();

                                using (var cmdGeneros = new SqlCommand(sqlGenres, con2))
                                {

                                    cmdGeneros.Parameters.AddWithValue("@AtorID", int.Parse(reader["AtorId"].ToString()));

                                    var readerGeneros = cmdGeneros.ExecuteReader();

                                    while (readerGeneros.Read())
                                    {
                                        generos.Add(new Genero(int.Parse(readerGeneros["GeneroID"].ToString()),
                                                                readerGeneros["Descricao"].ToString()));
                                    }

                                }
                            }

                            var ator = new Ator(
                                             int.Parse(reader["UsuarioID"].ToString()),
                                             int.Parse(reader["AtorID"].ToString()),
                                             reader["Nome"].ToString(),
                                             int.Parse(reader["Idade"].ToString()),
                                             char.Parse(reader["Sexo"].ToString()),
                                             generos,
                                             double.Parse(reader["Cache"].ToString()),
                                             reader["Status"].ToString(),
                                             int.Parse(reader["Relevancia"].ToString())
                                         );

                            return ator;
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








































        public async Task<int> InserirAtorAsync(Ator ator)
        {
            try
            {
                using (var con = new SqlConnection(_Configuration["ConnectionString"]))
                {
                    var sqlCmd = @"INSERT INTO 
                                    ATOR (
                                         UsuarioID
                                        ,Nome
                                        ,Idade
                                        ,Sexo
                                        ,Cache
                                        ,Status
                                        ,Relevancia
                                        ) 
                                    VALUES (
                                        @UsuarioID,
                                        @Nome, 
                                        @Idade,
                                        @Sexo, 
                                        @Cache,
                                        @Status,
                                        @Relevancia
                                        ); 
                                    SELECT scope_identity();";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        //Inserir o ID do usuário para vincular ao ator
                        cmd.Parameters.AddWithValue("UsuarioID", ator._UsuarioID);
                        cmd.Parameters.AddWithValue("Nome", ator._Nome);
                        cmd.Parameters.AddWithValue("Idade", ator._Idade);
                        cmd.Parameters.AddWithValue("Sexo", ator._Sexo);
                        cmd.Parameters.AddWithValue("Cache", ator._Cache);
                        cmd.Parameters.AddWithValue("Status", ator._Status);
                        cmd.Parameters.AddWithValue("Relevancia", ator._Relevancia);

                        con.Open();
                        var id = await cmd
                                        .ExecuteScalarAsync()
                                        .ConfigureAwait(false);

                        for(int i = 0; i < ator._Genero.Count; i++)
                        {
                            using (var con2 = new SqlConnection(_Configuration["ConnectionString"]))
                            {
                                var sql = @"INSERT INTO 
                                     ATORGENERO(
                                            AtorId, 
                                            GeneroId) 
                                VALUES (@AtorId, 
                                         @GeneroId);";

                                using (SqlCommand cmd2 = new SqlCommand(sql, con2))
                                {
                                    con2.Open();
                                    cmd2.CommandType = CommandType.Text;

                                    cmd2.Parameters.AddWithValue("AtorId", id);
                                    cmd2.Parameters.AddWithValue("GeneroId", ator._Genero[i]._Id);

                                    cmd2.ExecuteScalar();

                                }
                            }
                        }

                        return int.Parse(id.ToString());
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
