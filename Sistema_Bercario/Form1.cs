using System;
using System.Data;
using System.Windows.Forms;
using Sistema_Bercario.RespositorioDao;
using Sistema_Bercario.Models;

namespace Sistema_Bercario
{
    public partial class Form1 : Form
    {
        private AdministradorRepository adminRepository;

        public Form1()
        {
            InitializeComponent();
            adminRepository = new AdministradorRepository();
        }

        private void btnEntrarSistema_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obrigatórios
                if (string.IsNullOrWhiteSpace(txtNomeLogin.Text))
                {
                    MessageBox.Show("Por favor, digite o nome de usuário.", "Campo Obrigatório",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeLogin.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSenhaLogin.Text))
                {
                    MessageBox.Show("Por favor, digite a senha.", "Campo Obrigatório",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenhaLogin.Focus();
                    return;
                }

                // Desabilitar botão durante o processamento
                btnEntrarSistema.Enabled = false;
                btnEntrarSistema.Text = "Entrando...";

                // Tentar fazer login
                bool loginValido = adminRepository.ValidarLogin(txtNomeLogin.Text.Trim(), txtSenhaLogin.Text);

                if (loginValido)
                {
                    // Buscar dados do administrador
                    Administrador adminLogado = adminRepository.BuscarPorUsuario(txtNomeLogin.Text.Trim());

                    if (adminLogado != null)
                    {
                        MessageBox.Show($"Bem-vindo, {adminLogado.Usuario}!", "Login Realizado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir a tela principal do sistema
                        TelaPrincipal telaPrincipal = new TelaPrincipal(adminLogado);
                        telaPrincipal.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao carregar dados do usuário.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorretos.", "Login Inválido",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Limpar senha e focar no campo de usuário
                    txtSenhaLogin.Clear();
                    txtNomeLogin.Focus();
                    txtNomeLogin.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar login: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reabilitar botão
                btnEntrarSistema.Enabled = true;
                btnEntrarSistema.Text = "Entrar";
            }
        }

        private void btnIrCadastro_Click(object sender, EventArgs e)
        {
            IrParaCadastro();
        }

        private void IrParaCadastro()
        {
            try
            {
                CadastrarAdm formCadastro = new CadastrarAdm();
                formCadastro.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir tela de cadastro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNomeLogin.Clear();
            txtSenhaLogin.Clear();
            txtNomeLogin.Focus();
        }

        // Evento para navegar com Enter
        private void txtNomeLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenhaLogin.Focus();
            }
        }

        private void txtSenhaLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrarSistema.PerformClick();
            }
        }

        // Evento para fechar o formulário
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Método para testar conexão (mantido do código original)
        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();

            if (db.TestarConexao())
            {
                MessageBox.Show("Conexão OK! ✅");

                // Testar uma consulta
                try
                {
                    DataTable dados = db.ExecutarConsulta("SELECT COUNT(*) as total FROM administradores");
                    MessageBox.Show($"Encontrados {dados.Rows[0]["total"]} administradores");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro na consulta: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Falha na conexão! ❌");
            }
        }
    }
}