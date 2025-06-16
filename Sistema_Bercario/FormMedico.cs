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
    public partial class FormMedico : Form
    {
        private MedicoRepository _medicoRepository;
        private int _medicoSelecionadoId = 0;
        private bool _modoEdicao = false;

        public FormMedico()
        {
            InitializeComponent();
            _medicoRepository = new MedicoRepository();
            ConfigurarDataGridView();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impede redimensionamento
            this.MaximizeBox = false; // Remove o botão maximizar
            this.MinimizeBox = true;  // Opcional: deixa o botão minimizar
        }

        private void FormMedico_Load(object sender, EventArgs e)
        {
            CarregarMedicos();
            LimparCampos();
        }

        #region Configuração do DataGridView
        private void ConfigurarDataGridView()
        {
            // Configurações básicas do DataGridView
            dtgListMedico.AutoGenerateColumns = false;
            dtgListMedico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgListMedico.MultiSelect = false;
            dtgListMedico.ReadOnly = true;
            dtgListMedico.AllowUserToAddRows = false;
            dtgListMedico.AllowUserToDeleteRows = false;


            // Limpar colunas existentes
            dtgListMedico.Columns.Clear();

            // Criar colunas manualmente
            dtgListMedico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50,
                Visible = true
            });

            dtgListMedico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Width = 200
            });

            dtgListMedico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Crm",
                DataPropertyName = "Crm",
                HeaderText = "CRM",
                Width = 100
            });

            dtgListMedico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Especialidade",
                DataPropertyName = "Especialidade",
                HeaderText = "Especialidade",
                Width = 150
            });

            dtgListMedico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefone",
                DataPropertyName = "Telefone",
                HeaderText = "Telefone",
                Width = 120
            });

            dtgListMedico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Celular",
                DataPropertyName = "Celular",
                HeaderText = "Celular",
                Width = 120
            });

            dtgListMedico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                DataPropertyName = "Email",
                HeaderText = "E-mail",
                Width = 200
            });

            // Evento de seleção de linha
            dtgListMedico.SelectionChanged += DtgListMedico_SelectionChanged;
        }
        #endregion

        #region Eventos dos Botões
        private void btnSalvarMedico_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                var medico = new Medico
                {
                    Nome = txtNomeMedico.Text.Trim(),
                    Crm = txtCrmMedico.Text.Trim(),
                    Telefone = txtTelMedico.Text.Trim(),
                    Celular = txtMedicoCel.Text.Trim(),
                    Email = txtMedicoEmail.Text.Trim(),
                    Especialidade = txtEspecialidade.Text.Trim()
                };

                // Verificar se CRM já existe
                if (_medicoRepository.CrmJaExiste(medico.Crm))
                {
                    MessageBox.Show("Este CRM já está cadastrado no sistema!",
                        "CRM Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCrmMedico.Focus();
                    return;
                }

                bool sucesso = _medicoRepository.Inserir(medico);

                if (sucesso)
                {
                    MessageBox.Show("Médico cadastrado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarMedicos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar médico. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizarMedico_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _medicoSelecionadoId == 0)
                {
                    MessageBox.Show("Selecione um médico para atualizar!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                    return;

                var medico = new Medico
                {
                    Id = _medicoSelecionadoId,
                    Nome = txtNomeMedico.Text.Trim(),
                    Crm = txtCrmMedico.Text.Trim(),
                    Telefone = txtTelMedico.Text.Trim(),
                    Celular = txtMedicoCel.Text.Trim(),
                    Email = txtMedicoEmail.Text.Trim(),
                    Especialidade = txtEspecialidade.Text.Trim()
                };

                // Verificar se CRM já existe (excluindo o médico atual)
                if (_medicoRepository.CrmJaExiste(medico.Crm, medico.Id))
                {
                    MessageBox.Show("Este CRM já está cadastrado para outro médico!",
                        "CRM Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCrmMedico.Focus();
                    return;
                }

                bool sucesso = _medicoRepository.Atualizar(medico);

                if (sucesso)
                {
                    MessageBox.Show("Médico atualizado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarMedicos();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar médico. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeletarMedico_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _medicoSelecionadoId == 0)
                {
                    MessageBox.Show("Selecione um médico para excluir!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Tem certeza que deseja excluir o médico: {txtNomeMedico.Text}?\n\n" +
                    "Esta ação não pode ser desfeita e o médico será desativado no sistema.",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    bool sucesso = _medicoRepository.DesativarMedico(_medicoSelecionadoId);

                    if (sucesso)
                    {
                        MessageBox.Show("Médico excluído com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarMedicos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir médico. Tente novamente.",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        #endregion

        #region Métodos Auxiliares
        private void CarregarMedicos()
        {
            try
            {
                var medicos = _medicoRepository.ListarTodos();
                dtgListMedico.DataSource = medicos;
                dtgListMedico.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar médicos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtNomeMedico.Clear();
            txtCrmMedico.Clear();
            txtTelMedico.Clear();
            txtMedicoCel.Clear();
            txtMedicoEmail.Clear();
            txtEspecialidade.Clear();

            _medicoSelecionadoId = 0;
            _modoEdicao = false;

            dtgListMedico.ClearSelection();

            // Focar no primeiro campo
            txtNomeMedico.Focus();

            // Atualizar estado dos botões
            AtualizarEstadoBotoes();
        }

        private void AtualizarEstadoBotoes()
        {
            btnSalvarMedico.Enabled = !_modoEdicao;
            btnAtualizarMedico.Enabled = _modoEdicao;
            btnDeletarMedico.Enabled = _modoEdicao;
        }

        private bool ValidarCampos()
        {
            // Validar nome
            if (string.IsNullOrWhiteSpace(txtNomeMedico.Text))
            {
                MessageBox.Show("Por favor, informe o nome do médico.",
                    "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeMedico.Focus();
                return false;
            }

            // Validar CRM
            if (string.IsNullOrWhiteSpace(txtCrmMedico.Text))
            {
                MessageBox.Show("Por favor, informe o CRM do médico.",
                    "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCrmMedico.Focus();
                return false;
            }

            // Validar formato do e-mail (se preenchido)
            if (!string.IsNullOrWhiteSpace(txtMedicoEmail.Text) && !IsValidEmail(txtMedicoEmail.Text))
            {
                MessageBox.Show("Por favor, informe um e-mail válido.",
                    "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedicoEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void DtgListMedico_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgListMedico.SelectedRows.Count > 0)
            {
                var linhaSelecionada = dtgListMedico.SelectedRows[0];
                if (linhaSelecionada.DataBoundItem is Medico medico)
                {
                    PreencherCampos(medico);
                }
                // var medico = (Medico)linhaSelecionada.DataBoundItem;

                //if (medico != null)
                //{
                //    PreencherCampos(medico);
                //}
            }
        }

        private void DtgListMedico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgListMedico.Rows[e.RowIndex];
                if (row.DataBoundItem is Medico medico)
                {
                    PreencherCampos(medico);
                }
            }
        }

        private void PreencherCampos(Medico medico)
        {
            _medicoSelecionadoId = medico.Id;
            _modoEdicao = true;

            txtNomeMedico.Text = medico.Nome ?? "";
            txtCrmMedico.Text = medico.Crm ?? "";
            txtTelMedico.Text = medico.Telefone ?? "";
            txtMedicoCel.Text = medico.Celular ?? "";
            txtMedicoEmail.Text = medico.Email ?? "";
            txtEspecialidade.Text = medico.Especialidade ?? "";

            AtualizarEstadoBotoes();
        }
        #endregion

        #region Eventos de Validação em Tempo Real
        private void txtNomeMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas letras, espaços e backspace
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtCrmMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, letras e backspace (formato CRM pode variar)
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtTelMedico_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, parênteses, hífen, espaço e backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')' &&
                e.KeyChar != '-' && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtMedicoCel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, parênteses, hífen, espaço e backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')' &&
                e.KeyChar != '-' && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}