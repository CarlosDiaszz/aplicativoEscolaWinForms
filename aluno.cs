using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AplicativoEscola
{
    public class Aluno
    {
        // Propriedades
        public string nomeAluno { get; set; }
        public string dataNascimentoAluno { get; set; }
        public string nomeResponsavel { get; set; }
        public string dataNascimentoResponsavel { get; set; }
        public string turmas { get; set; }
        public int _idAluno { get; set; }
        public string _telefoneResponsavel { get; private set; }
        public string _cpfResponsavel { get; private set; }

        // CONSTRUTOR ATUALIZADO (7 Parâmetros)
        public Aluno(string nomeAlunofrm, string dataNascimentoAlunofrm, string nomeReponsavelfrm, string dataNascimentoResponsavelfrm, string turmasfrm, string _telefoneResponsavelfrm, string _cpfResponsavelfrm)
        {
            nomeAluno = nomeAlunofrm;
            dataNascimentoAluno = dataNascimentoAlunofrm;
            nomeResponsavel = nomeReponsavelfrm;
            dataNascimentoResponsavel = dataNascimentoResponsavelfrm;
            turmas = turmasfrm;
            _telefoneResponsavel = _telefoneResponsavelfrm;
            _cpfResponsavel = _cpfResponsavelfrm;
        }

        public void CadastrarAluno()
        {
            try
            {
                Conexao conexao = new Conexao();
                // SQL incluindo o campo 'turmas'
                string sql = "INSERT INTO aluno (nomeAluno, dataNascimentoAluno, nomeResponsavel, dataNascimentoResponsavel, telefoneResponsavel, cpfResponsavel, turmas) " +
                             "VALUES (@nomeAluno, @dataNascimentoAluno, @nomeResponsavel, @dataNascimentoResponsavel, @telefoneResponsavel, @cpfResponsavel, @turmas)";

                conexao.AbrirConexao();
                MySqlCommand comando = new MySqlCommand(sql, conexao.conexao);

                comando.Parameters.AddWithValue("@nomeAluno", nomeAluno);
                comando.Parameters.AddWithValue("@dataNascimentoAluno", dataNascimentoAluno);
                comando.Parameters.AddWithValue("@nomeResponsavel", nomeResponsavel);
                comando.Parameters.AddWithValue("@dataNascimentoResponsavel", dataNascimentoResponsavel);
                comando.Parameters.AddWithValue("@telefoneResponsavel", _telefoneResponsavel);
                comando.Parameters.AddWithValue("@cpfResponsavel", _cpfResponsavel);
                comando.Parameters.AddWithValue("@turmas", turmas);

                comando.ExecuteNonQuery();
                conexao.FecharConexao();

                MessageBox.Show("Aluno cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar no Banco de Dados: " + ex.Message);
            }
        }
    }
}