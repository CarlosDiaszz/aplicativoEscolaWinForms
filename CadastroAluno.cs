using AplicativoEscola;
using System;
using System.Windows.Forms;

namespace CrudEscola
{
    public partial class cadastroAluno : Form
    {
        public cadastroAluno()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                // Criando o objeto com os 7 campos na ORDEM EXATA do construtor acima
                Aluno novo = new Aluno(
                    txtAluno.Text,                  // 1. nomeAlunofrm
                    txtDataAluno.Text,              // 2. dataNascimentoAlunofrm
                    txtNomeResponsavel.Text,        // 3. nomeReponsavelfrm
                    txtDataResponsavel.Text,        // 4. dataNascimentoResponsavelfrm
                    txtTurma.Text,                  // 5. turmasfrm
                    txtTelefoneResponsavel.Text,    // 6. _telefoneResponsavelfrm
                    txtCpfResponsavel.Text          // 7. _cpfResponsavelfrm
                );

                // Chama o método da classe para salvar no MySQL
                novo.CadastrarAluno();

                // Limpa a tela para o próximo
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na interface: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtAluno.Clear();
            txtDataAluno.Clear();
            txtNomeResponsavel.Clear();
            txtDataResponsavel.Clear();
            txtTelefoneResponsavel.Clear();
            txtCpfResponsavel.Clear();
            txtTurma.Clear();
            txtAluno.Focus();
        }
    }
}