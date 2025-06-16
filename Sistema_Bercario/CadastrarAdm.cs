using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_Bercario.Models;
using Sistema_Bercario.RespositorioDao;

namespace Sistema_Bercario
{
    public partial class CadastrarAdm : Form
    {
        private AdministradorRepository adminRepository;

        public CadastrarAdm()
        {
            InitializeComponent();
            adminRepository = new AdministradorRepository();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos obrigatórios
                if (string.IsNullOrWhiteSpace(txtNomeAdm.Text))
                {
                    MessageBox.Show("Por favor, digite o nome do administrador.", "Campo Obrigatório",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeAdm.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtSenhaAdm.Text))
                {
                    MessageBox.Show("Por favor, digite uma senha.", "Campo Obrigatório",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenhaAdm.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCodigoHosp.Text))
                {
                    MessageBox.Show("Por favor, digite o código do hospital.", "Campo Obrigatório",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoHosp.Focus();
                    return;
                }

                // Validar código do hospital
                if (txtCodigoHosp.Text.Trim() != "01110110")
                {
                    MessageBox.Show("Código do hospital inválido. Verifique e tente novamente.", "Código Inválido",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigoHosp.Focus();
                    txtCodigoHosp.SelectAll();
                    return;
                }

                // Validar se o usuário já existe
                if (adminRepository.UsuarioJaExiste(txtNomeAdm.Text.Trim()))
                {
                    MessageBox.Show("Já existe um administrador com este nome de usuário.", "Usuário Existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeAdm.Focus();
                    txtNomeAdm.SelectAll();
                    return;
                }

                // Validar senha (mínimo 4 caracteres)
                if (txtSenhaAdm.Text.Length < 4)
                {
                    MessageBox.Show("A senha deve ter pelo menos 4 caracteres.", "Senha Inválida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenhaAdm.Focus();
                    txtSenhaAdm.SelectAll();
                    return;
                }

                // Criar o objeto Administrador
                Administrador novoAdmin = new Administrador
                {
                    Usuario = txtNomeAdm.Text.Trim(),
                    Senha = txtSenhaAdm.Text,
                    CodHosp = txtCodigoHosp.Text.Trim()
                };

                // Tentar cadastrar
                bool sucesso = adminRepository.CriarAdministrador(novoAdmin);

                if (sucesso)
                {
                    MessageBox.Show("Administrador cadastrado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpar campos
                    LimparCampos();

                    // Perguntar se deseja ir para o login
                    DialogResult resultado = MessageBox.Show("Deseja ir para a tela de login agora?", "Cadastro Concluído",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        IrParaLogin();
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar administrador. Tente novamente.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIrLogin_Click(object sender, EventArgs e)
        {
            IrParaLogin();
        }

        private void IrParaLogin()
        {
            try
            {
                Form1 formLogin = new Form1();
                formLogin.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir tela de login: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNomeAdm.Clear();
            txtSenhaAdm.Clear();
            txtCodigoHosp.Clear();
            txtNomeAdm.Focus();
        }

        // Evento para permitir apenas números no código do hospital
        private void txtCodigoHosp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, backspace e delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Evento para limitar o tamanho do código do hospital
        private void txtCodigoHosp_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoHosp.Text.Length > 8)
            {
                txtCodigoHosp.Text = txtCodigoHosp.Text.Substring(0, 8);
                txtCodigoHosp.SelectionStart = txtCodigoHosp.Text.Length;
            }
        }

        // Evento para navegar com Enter
        private void txtNomeAdm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenhaAdm.Focus();
            }
        }

        private void txtSenhaAdm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCodigoHosp.Focus();
            }
        }

        private void txtCodigoHosp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCadastro.PerformClick();
            }
        }

        // Evento para fechar o formulário
        private void CadastrarAdm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}