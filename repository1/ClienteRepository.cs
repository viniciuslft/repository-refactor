using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace repository1
{
    class ClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository()
        {
            _connectionString =
                ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
        }

        public bool Inserir(Cliente cliente)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();
                    string sql = "INSERT INTO Clientes (IdClientes, Nome, Endereco, Telefone) " +
                                 "VALUES (@vId, @vNome, @vEndereco, @vTelefone)";
                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("vId", cliente.IdClientes);
                    comando.Parameters.AddWithValue("vNome", cliente.Nome);
                    comando.Parameters.AddWithValue("vEndereco", cliente.Endereco);
                    comando.Parameters.AddWithValue("vTelefone", cliente.Telefone);

                    return comando.ExecuteNonQuery() > 0;
                }
                catch
                {
                    throw;
                }
            }
        }

        // ✅ Adicione os métodos novos AQUI EMBAIXO ⬇

        public Cliente BuscarPorId(int id)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();
                    string sql = "SELECT * FROM Clientes WHERE IdClientes = @vId";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("vId", id);

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                IdClientes = Convert.ToInt32(reader["IdClientes"]),
                                Nome = reader["Nome"].ToString(),
                                Endereco = reader["Endereco"].ToString(),
                                Telefone = reader["Telefone"].ToString()
                            };
                        }
                    }

                    return null;
                }
                catch
                {
                    throw;
                }
            }
        }

        public bool Atualizar(Cliente cliente)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();
                    string sql = "UPDATE Clientes SET Nome = @vNome, Endereco = @vEndereco, Telefone = @vTelefone WHERE IdClientes = @vId";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("vId", cliente.IdClientes);
                    comando.Parameters.AddWithValue("vNome", cliente.Nome);
                    comando.Parameters.AddWithValue("vEndereco", cliente.Endereco);
                    comando.Parameters.AddWithValue("vTelefone", cliente.Telefone);

                    return comando.ExecuteNonQuery() > 0;
                }
                catch
                {
                    throw;
                }
            }
        }

        public bool Excluir(int id)
        {
            using (MySqlConnection conexao = new MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();
                    string sql = "DELETE FROM Clientes WHERE IdClientes = @vId";

                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("vId", id);

                    return comando.ExecuteNonQuery() > 0;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}