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
    public partial class FormEnfermeira : Form
    {
        private EnfermeiraRepository _enfermeiraRepository;
        private int _enfermeiraIdSelecionada = 0;
        private bool _modoEdicao = false;

        public FormEnfermeira()
        {
            InitializeComponent();
            _enfermeiraRepository = new EnfermeiraRepository();
            ConfigurarFormulario();
        }

        private void FormEnfermeira_Load(object sender, EventArgs e)
        {
            CarregarEnfermeiras();
            LimparCampos();
        }

        private void ConfigurarFormulario()
        {
            // Configurar eventos dos botões
            btnSalvarEnfermeira.Click += BtnSalvarEnfermeira_Click;
            btnLimparCampos.Click += BtnLimparCampos_Click;
            btnAtualizarEnfermeira.Click += BtnAtualizarEnfermeira_Click;
            btnDeletarEnfermeira.Click += BtnDeletarEnfermeira_Click;

            // Configurar evento de seleção do DataGridView
            dtgListEnfermeira.SelectionChanged += DtgListEnfermeira_SelectionChanged;
            dtgListEnfermeira.CellDoubleClick += DtgListEnfermeira_CellDoubleClick;
            dtgListEnfermeira.CellClick += DtgListEnfermeira_CellClick;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Configurar validações nos campos
            ConfigurarValidacoesCampos();
        }

        private void ConfigurarDataGridView()
        {
            dtgListEnfermeira.AutoGenerateColumns = false;
            dtgListEnfermeira.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgListEnfermeira.MultiSelect = false;
            dtgListEnfermeira.ReadOnly = true;
            dtgListEnfermeira.AllowUserToAddRows = false;
            dtgListEnfermeira.AllowUserToDeleteRows = false;

            // Limpar colunas existentes
            dtgListEnfermeira.Columns.Clear();

            // Adicionar colunas personalizadas
            dtgListEnfermeira.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                Visible = true
            });

            dtgListEnfermeira.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                Width = 200
            });

            dtgListEnfermeira.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Coren",
                HeaderText = "COREN",
                DataPropertyName = "Coren",
                Width = 100
            });

            dtgListEnfermeira.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefone",
                HeaderText = "Telefone",
                DataPropertyName = "Telefone",
                Width = 100
            });

            dtgListEnfermeira.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Celular",
                HeaderText = "Celular",
                DataPropertyName = "Celular",
                Width = 100
            });

            dtgListEnfermeira.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "E-mail",
                DataPropertyName = "Email",
                Width = 200
            });

            dtgListEnfermeira.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StatusAtivo",
                HeaderText = "Status",
                DataPropertyName = "StatusAtivo",
                Width = 80
            });
        }

        private void ConfigurarValidacoesCampos()
        {
            // Limitar caracteres nos campos
            txtNomeEnfermeira.MaxLength = 100;
            txtCorenEnfermeira.MaxLength = 20;
            txtTelEnfermeira.MaxLength = 15;
            txtCelEnfermeira.MaxLength = 15;
            txtEmailEnfermeira.MaxLength = 100;

            // Validação em tempo real do COREN
            txtCorenEnfermeira.Leave += TxtCorenEnfermeira_Leave;
            txtEmailEnfermeira.Leave += TxtEmailEnfermeira_Leave;
        }

        private void TxtCorenEnfermeira_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCorenEnfermeira.Text))
            {
                if (_enfermeiraRepository.CorenJaExiste(txtCorenEnfermeira.Text, _modoEdicao ? _enfermeiraIdSelecionada : null))
                {
                    MessageBox.Show("Este número de COREN já está cadastrado!", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorenEnfermeira.Focus();
                }
            }
        }

        private void TxtEmailEnfermeira_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmailEnfermeira.Text))
            {
                if (!IsValidEmail(txtEmailEnfermeira.Text))
                {
                    MessageBox.Show("Por favor, insira um e-mail válido!", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailEnfermeira.Focus();
                }
            }
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

        private void CarregarEnfermeiras()
        {
            try
            {
                var enfermeiras = _enfermeiraRepository.ListarTodas();

                // Preparar dados para exibição com status formatado
                var dadosParaExibicao = enfermeiras.Select(e => new
                {
                    e.Id,
                    e.Nome,
                    e.Coren,
                    e.Telefone,
                    e.Celular,
                    e.Email,
                    StatusAtivo = e.StatusAtivo ? "Ativo" : "Inativo"
                }).ToList();

                dtgListEnfermeira.DataSource = dadosParaExibicao;
                dtgListEnfermeira.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar enfermeiras: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarEstadoBotoes()
        {
            btnSalvarEnfermeira.Enabled = !_modoEdicao;
            btnAtualizarEnfermeira.Enabled = _modoEdicao;
            btnDeletarEnfermeira.Enabled = _modoEdicao;
        }

        private void BtnSalvarEnfermeira_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                var enfermeira = new Enfermeira
                {
                    Nome = txtNomeEnfermeira.Text.Trim(),
                    Coren = txtCorenEnfermeira.Text.Trim(),
                    Telefone = txtTelEnfermeira.Text.Trim(),
                    Celular = txtCelEnfermeira.Text.Trim(),
                    Email = txtEmailEnfermeira.Text.Trim()
                };

                // Verificar se COREN já existe
                if (_enfermeiraRepository.CorenJaExiste(enfermeira.Coren))
                {
                    MessageBox.Show("Este COREN já está cadastrado no sistema!",
                        "COREN Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorenEnfermeira.Focus();
                    return;
                }

                bool sucesso = _enfermeiraRepository.Inserir(enfermeira);

                if (sucesso)
                {
                    MessageBox.Show("Enfermeira cadastrada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarEnfermeiras();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar enfermeira. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtualizarEnfermeira_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _enfermeiraIdSelecionada == 0)
                {
                    MessageBox.Show("Selecione uma enfermeira para atualizar!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                    return;

                var enfermeira = new Enfermeira
                {
                    Id = _enfermeiraIdSelecionada,
                    Nome = txtNomeEnfermeira.Text.Trim(),
                    Coren = txtCorenEnfermeira.Text.Trim(),
                    Telefone = txtTelEnfermeira.Text.Trim(),
                    Celular = txtCelEnfermeira.Text.Trim(),
                    Email = txtEmailEnfermeira.Text.Trim()
                };

                // Verificar se COREN já existe (excluindo a enfermeira atual)
                if (_enfermeiraRepository.CorenJaExiste(enfermeira.Coren, enfermeira.Id))
                {
                    MessageBox.Show("Este COREN já está cadastrado para outra enfermeira!",
                        "COREN Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorenEnfermeira.Focus();
                    return;
                }

                bool sucesso = _enfermeiraRepository.Atualizar(enfermeira);

                if (sucesso)
                {
                    MessageBox.Show("Enfermeira atualizada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarEnfermeiras();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar enfermeira. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeletarEnfermeira_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _enfermeiraIdSelecionada == 0)
                {
                    MessageBox.Show("Selecione uma enfermeira para excluir!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Tem certeza que deseja excluir a enfermeira: {txtNomeEnfermeira.Text}?\n\n" +
                    "Esta ação não pode ser desfeita e a enfermeira será desativada no sistema.",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    bool sucesso = _enfermeiraRepository.DesativarEnfermeira(_enfermeiraIdSelecionada);

                    if (sucesso)
                    {
                        MessageBox.Show("Enfermeira excluída com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarEnfermeiras();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir enfermeira. Tente novamente.",
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

        private void BtnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void DtgListEnfermeira_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgListEnfermeira.SelectedRows.Count > 0)
            {
                var linhaSelecionada = dtgListEnfermeira.SelectedRows[0];

                // Como estamos usando um objeto anônimo, precisamos acessar pelos nomes das propriedades
                if (linhaSelecionada.Cells["Id"].Value != null)
                {
                    var enfermeira = new Enfermeira
                    {
                        Id = Convert.ToInt32(linhaSelecionada.Cells["Id"].Value),
                        Nome = linhaSelecionada.Cells["Nome"].Value?.ToString() ?? "",
                        Coren = linhaSelecionada.Cells["Coren"].Value?.ToString() ?? "",
                        Telefone = linhaSelecionada.Cells["Telefone"].Value?.ToString() ?? "",
                        Celular = linhaSelecionada.Cells["Celular"].Value?.ToString() ?? "",
                        Email = linhaSelecionada.Cells["Email"].Value?.ToString() ?? ""
                    };

                    PreencherCampos(enfermeira);
                }
            }
        }

        private void DtgListEnfermeira_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // O duplo clique já vai acionar a seleção, então os campos serão preenchidos automaticamente
                txtNomeEnfermeira.Focus();
            }
        }

        private void DtgListEnfermeira_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgListEnfermeira.Rows[e.RowIndex];

                if (row.Cells["Id"].Value != null)
                {
                    var enfermeira = new Enfermeira
                    {
                        Id = Convert.ToInt32(row.Cells["Id"].Value),
                        Nome = row.Cells["Nome"].Value?.ToString() ?? "",
                        Coren = row.Cells["Coren"].Value?.ToString() ?? "",
                        Telefone = row.Cells["Telefone"].Value?.ToString() ?? "",
                        Celular = row.Cells["Celular"].Value?.ToString() ?? "",
                        Email = row.Cells["Email"].Value?.ToString() ?? ""
                    };

                    PreencherCampos(enfermeira);
                }
            }
        }

        private void PreencherCampos(Enfermeira enfermeira)
        {
            _enfermeiraIdSelecionada = enfermeira.Id;
            _modoEdicao = true;

            txtNomeEnfermeira.Text = enfermeira.Nome ?? "";
            txtCorenEnfermeira.Text = enfermeira.Coren ?? "";
            txtTelEnfermeira.Text = enfermeira.Telefone ?? "";
            txtCelEnfermeira.Text = enfermeira.Celular ?? "";
            txtEmailEnfermeira.Text = enfermeira.Email ?? "";

            AtualizarEstadoBotoes();
        }

        private void LimparCampos()
        {
            txtNomeEnfermeira.Clear();
            txtCorenEnfermeira.Clear();
            txtTelEnfermeira.Clear();
            txtCelEnfermeira.Clear();
            txtEmailEnfermeira.Clear();

            _enfermeiraIdSelecionada = 0;
            _modoEdicao = false;

            dtgListEnfermeira.ClearSelection();

            // Focar no primeiro campo
            txtNomeEnfermeira.Focus();

            // Atualizar estado dos botões
            AtualizarEstadoBotoes();
        }

        private bool ValidarCampos()
        {
            // Validar campo obrigatório: Nome
            if (string.IsNullOrWhiteSpace(txtNomeEnfermeira.Text))
            {
                MessageBox.Show("Por favor, informe o nome da enfermeira.",
                    "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeEnfermeira.Focus();
                return false;
            }

            // Validar campo obrigatório: COREN
            if (string.IsNullOrWhiteSpace(txtCorenEnfermeira.Text))
            {
                MessageBox.Show("Por favor, informe o número do COREN.",
                    "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorenEnfermeira.Focus();
                return false;
            }

            // Validar e-mail se preenchido
            if (!string.IsNullOrWhiteSpace(txtEmailEnfermeira.Text) && !IsValidEmail(txtEmailEnfermeira.Text))
            {
                MessageBox.Show("Por favor, insira um e-mail válido!", "E-mail Inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailEnfermeira.Focus();
                return false;
            }

            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregarEnfermeiras();
            LimparCampos();
        }
    }
}