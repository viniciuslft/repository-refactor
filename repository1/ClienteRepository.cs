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
             ConfigurationManager.
             ConnectionStrings["MySQLConnectionString"].ToString();
        }
        public bool Inserir(Cliente cliente)
        {
            using (MySqlConnection conexao = new
            MySqlConnection(_connectionString))
            {
                try
                {
                    conexao.Open();
                    string sql = "INSERT INTO Clientes (IdClientes, Nome,Endereco, Telefone) " + "VALUES (@vId, @vNome, @vEndereco,@vTelefone)";
                    MySqlCommand comando = new
                    MySqlCommand(sql, conexao);
                    comando.Parameters.AddWithValue("vId",
                    cliente.IdClientes);
                    comando.Parameters.AddWithValue("vNome",
                    cliente.Nome);
                    comando.Parameters.AddWithValue("vEndereco",
                    cliente.Endereco);
                    comando.Parameters.AddWithValue("vTelefone",
                    cliente.Telefone);

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