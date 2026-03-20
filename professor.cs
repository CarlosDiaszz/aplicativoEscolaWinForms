using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AplicativoEscola
{
    public class Professor
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }

        Conexao conexao = new Conexao();
        string sql;
        MySqlCommand comando;

        public Professor(string nome, string email, string telefone, string cpf, string senha)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            Senha = senha;
        }

        public void CadastrarProfessor()
        {
            try
            {
                conexao.AbrirConexao();

                sql = "INSERT INTO professor (Nome, Email, Telefone, Cpf, Senha) " +
                      "VALUES (@Nome, @Email, @Telefone, @Cpf, @Senha)";

                comando = new MySqlCommand(sql, conexao.conexao);

                comando.Parameters.AddWithValue("@Nome", Nome);
                comando.Parameters.AddWithValue("@Email", Email);
                comando.Parameters.AddWithValue("@Telefone", Telefone);
                comando.Parameters.AddWithValue("@Cpf", Cpf);
                comando.Parameters.AddWithValue("@Senha", Senha);

                comando.ExecuteNonQuery();

                MessageBox.Show("Professor cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
    }
}