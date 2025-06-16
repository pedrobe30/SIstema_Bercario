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
    public partial class FormMãe : Form
    {
        private MaeRepository _maeRepository;
        private int _maeIdSelecionada = 0;
        private bool _modoEdicao = false;

        public FormMãe()
        {
            InitializeComponent();
            _maeRepository = new MaeRepository();
            ConfigurarFormulario();
        }

        private void FormMãe_Load(object sender, EventArgs e)
        {
            CarregarMaes();
            LimparCampos();
        }

        private void ConfigurarFormulario()
        {
            // Configurar eventos dos botões
            btnSalvarMae.Click += BtnSalvarMae_Click;
            btnLimparCampos.Click += BtnLimparCampos_Click;
            btnAtualizarMae.Click += BtnAtualizarMae_Click;
            btnDeletarMae.Click += BtnDeletarMae_Click;

            // Configurar evento de seleção do DataGridView
            dtgListMae.SelectionChanged += DtgListMae_SelectionChanged;
            dtgListMae.CellDoubleClick += DtgListMae_CellDoubleClick;
            dtgListMae.CellClick += DtgListMae_CellClick;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Configurar validações nos campos
            ConfigurarValidacoesCampos();
        }

        private void ConfigurarDataGridView()
        {
            dtgListMae.AutoGenerateColumns = false;
            dtgListMae.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgListMae.MultiSelect = false;
            dtgListMae.ReadOnly = true;
            dtgListMae.AllowUserToAddRows = false;
            dtgListMae.AllowUserToDeleteRows = false;

            // Limpar colunas existentes
            dtgListMae.Columns.Clear();

            // Adicionar colunas personalizadas
            dtgListMae.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50,
                Visible = true
            });

            dtgListMae.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                Width = 200
            });

            dtgListMae.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cpf",
                HeaderText = "CPF",
                DataPropertyName = "Cpf",
                Width = 120
            });

            dtgListMae.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataNascimento",
                HeaderText = "Data Nascimento",
                DataPropertyName = "DataNascimentoFormatada",
                Width = 120
            });

            dtgListMae.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Telefone",
                HeaderText = "Telefone",
                DataPropertyName = "Telefone",
                Width = 100
            });

            dtgListMae.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Celular",
                HeaderText = "Celular",
                DataPropertyName = "Celular",
                Width = 100
            });

            dtgListMae.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Endereco",
                HeaderText = "Endereço",
                DataPropertyName = "Endereco",
                Width = 250
            });

            dtgListMae.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataCadastro",
                HeaderText = "Data Cadastro",
                DataPropertyName = "DataCadastroFormatada",
                Width = 120
            });
        }

        private void ConfigurarValidacoesCampos()
        {
            // Limitar caracteres nos campos
            txtNomeMae.MaxLength = 100;
            txtCpfMae.MaxLength = 14;
            txtTelMae.MaxLength = 15;
            txtCelMae.MaxLength = 15;
            txtRua.MaxLength = 200;
            txtNumero.MaxLength = 10;
            txtBairro.MaxLength = 100;
            txtCidade.MaxLength = 100;

            // Validação em tempo real do CPF
            txtCpfMae.Leave += TxtCpfMae_Leave;
            txtCpfMae.KeyPress += TxtCpfMae_KeyPress;
            txtTelMae.KeyPress += TxtTelefone_KeyPress;
            txtCelMae.KeyPress += TxtTelefone_KeyPress;
            txtNumero.KeyPress += TxtNumero_KeyPress;

            // Formatação automática do CPF
            txtCpfMae.TextChanged += TxtCpfMae_TextChanged;
        }

        private void TxtCpfMae_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCpfMae.Text))
            {
                string cpfLimpo = LimparCpf(txtCpfMae.Text);

                if (!ValidarCpf(cpfLimpo))
                {
                    MessageBox.Show("CPF inválido! Por favor, verifique os números digitados.", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCpfMae.Focus();
                    return;
                }

                if (_maeRepository.CpfJaExiste(cpfLimpo, _modoEdicao ? _maeIdSelecionada : null))
                {
                    MessageBox.Show("Este CPF já está cadastrado!", "Validação",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCpfMae.Focus();
                }
            }
        }

        private void TxtCpfMae_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, backspace e delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, backspace, delete, parênteses, hífen e espaço
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void TxtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtCpfMae_TextChanged(object sender, EventArgs e)
        {
            // Formatação automática do CPF durante a digitação
            TextBox txt = sender as TextBox;
            string cpf = txt.Text.Replace(".", "").Replace("-", "");

            if (cpf.Length <= 11)
            {
                if (cpf.Length > 3 && cpf.Length <= 6)
                    txt.Text = cpf.Substring(0, 3) + "." + cpf.Substring(3);
                else if (cpf.Length > 6 && cpf.Length <= 9)
                    txt.Text = cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) + "." + cpf.Substring(6);
                else if (cpf.Length > 9)
                    txt.Text = cpf.Substring(0, 3) + "." + cpf.Substring(3, 3) + "." + cpf.Substring(6, 3) + "-" + cpf.Substring(9);

                txt.SelectionStart = txt.Text.Length;
            }
        }

        private string LimparCpf(string cpf)
        {
            return cpf.Replace(".", "").Replace("-", "").Trim();
        }

        private bool ValidarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                return false;

            // Verificar se todos os dígitos são iguais
            if (cpf.All(c => c == cpf[0]))
                return false;

            // Calcular primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);

            int resto = soma % 11;
            int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

            if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
                return false;

            // Calcular segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);

            resto = soma % 11;
            int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

            return int.Parse(cpf[10].ToString()) == digitoVerificador2;
        }

        private void CarregarMaes()
        {
            try
            {
                var maes = _maeRepository.ListarTodas();

                // Preparar dados para exibição com formatação
                var dadosParaExibicao = maes.Select(m => new
                {
                    m.Id,
                    m.Nome,
                    m.Cpf,
                    DataNascimentoFormatada = m.DataNascimento?.ToString("dd/MM/yyyy") ?? "",
                    m.Telefone,
                    m.Celular,
                    m.Endereco,
                    DataCadastroFormatada = m.DataCadastro.ToString("dd/MM/yyyy HH:mm")
                }).ToList();

                dtgListMae.DataSource = dadosParaExibicao;
                dtgListMae.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar mães: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarEstadoBotoes()
        {
            btnSalvarMae.Enabled = !_modoEdicao;
            btnAtualizarMae.Enabled = _modoEdicao;
            btnDeletarMae.Enabled = _modoEdicao;
        }

        private void BtnSalvarMae_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                string enderecoCompleto = MontarEnderecoCompleto();

                var mae = new Mae
                {
                    Nome = txtNomeMae.Text.Trim(),
                    Cpf = LimparCpf(txtCpfMae.Text),
                    DataNascimento = dateTimePickerMae.Checked ? dateTimePickerMae.Value.Date : (DateTime?)null,
                    Endereco = enderecoCompleto,
                    Telefone = txtTelMae.Text.Trim(),
                    Celular = txtCelMae.Text.Trim()
                };

                // Verificar se CPF já existe
                if (_maeRepository.CpfJaExiste(mae.Cpf))
                {
                    MessageBox.Show("Este CPF já está cadastrado no sistema!",
                        "CPF Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCpfMae.Focus();
                    return;
                }

                bool sucesso = _maeRepository.Inserir(mae);

                if (sucesso)
                {
                    MessageBox.Show("Mãe cadastrada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarMaes();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar mãe. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtualizarMae_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _maeIdSelecionada == 0)
                {
                    MessageBox.Show("Selecione uma mãe para atualizar!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                    return;

                string enderecoCompleto = MontarEnderecoCompleto();

                var mae = new Mae
                {
                    Id = _maeIdSelecionada,
                    Nome = txtNomeMae.Text.Trim(),
                    Cpf = LimparCpf(txtCpfMae.Text),
                    DataNascimento = dateTimePickerMae.Checked ? dateTimePickerMae.Value.Date : (DateTime?)null,
                    Endereco = enderecoCompleto,
                    Telefone = txtTelMae.Text.Trim(),
                    Celular = txtCelMae.Text.Trim()
                };

                // Verificar se CPF já existe (excluindo a mãe atual)
                if (_maeRepository.CpfJaExiste(mae.Cpf, mae.Id))
                {
                    MessageBox.Show("Este CPF já está cadastrado para outra mãe!",
                        "CPF Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCpfMae.Focus();
                    return;
                }

                bool sucesso = _maeRepository.Atualizar(mae);

                if (sucesso)
                {
                    MessageBox.Show("Mãe atualizada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarMaes();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar mãe. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeletarMae_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _maeIdSelecionada == 0)
                {
                    MessageBox.Show("Selecione uma mãe para excluir!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verificar se a mãe pode ser excluída
                if (!_maeRepository.PodeExcluir(_maeIdSelecionada))
                {
                    MessageBox.Show(
                        "Não é possível excluir esta mãe pois ela possui bebês cadastrados.\n\n" +
                        "Para excluir uma mãe, primeiro é necessário remover todos os bebês relacionados a ela.",
                        "Exclusão não permitida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Tem certeza que deseja excluir a mãe: {txtNomeMae.Text}?\n\n" +
                    "ATENÇÃO: Esta ação não pode ser desfeita!",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    bool sucesso = _maeRepository.Excluir(_maeIdSelecionada);

                    if (sucesso)
                    {
                        MessageBox.Show("Mãe excluída com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarMaes();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir mãe. Tente novamente.",
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

        private void DtgListMae_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgListMae.SelectedRows.Count > 0)
            {
                var linhaSelecionada = dtgListMae.SelectedRows[0];

                if (linhaSelecionada.Cells["Id"].Value != null)
                {
                    int idSelecionado = Convert.ToInt32(linhaSelecionada.Cells["Id"].Value);
                    var mae = _maeRepository.BuscarPorId(idSelecionado);

                    if (mae != null)
                    {
                        PreencherCampos(mae);
                    }
                }
            }
        }

        private void DtgListMae_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNomeMae.Focus();
            }
        }

        private void DtgListMae_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgListMae.Rows[e.RowIndex];

                if (row.Cells["Id"].Value != null)
                {
                    int idSelecionado = Convert.ToInt32(row.Cells["Id"].Value);
                    var mae = _maeRepository.BuscarPorId(idSelecionado);

                    if (mae != null)
                    {
                        PreencherCampos(mae);
                    }
                }
            }
        }

        private void PreencherCampos(Mae mae)
        {
            _maeIdSelecionada = mae.Id;
            _modoEdicao = true;

            txtNomeMae.Text = mae.Nome ?? "";
            txtCpfMae.Text = mae.Cpf ?? "";

            if (mae.DataNascimento.HasValue)
            {
                dateTimePickerMae.Value = mae.DataNascimento.Value;
                dateTimePickerMae.Checked = true;
            }
            else
            {
                dateTimePickerMae.Checked = false;
            }

            txtTelMae.Text = mae.Telefone ?? "";
            txtCelMae.Text = mae.Celular ?? "";

            // Separar o endereço completo nos campos individuais
            SepararEndereco(mae.Endereco ?? "");

            AtualizarEstadoBotoes();
        }

        private void SepararEndereco(string enderecoCompleto)
        {
            // Limpar campos
            txtRua.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";

            if (string.IsNullOrWhiteSpace(enderecoCompleto))
                return;

            // Tentar separar o endereço (formato livre, pode não seguir padrão)
            txtRua.Text = enderecoCompleto;
        }

        private string MontarEnderecoCompleto()
        {
            var enderecoParts = new List<string>();

            if (!string.IsNullOrWhiteSpace(txtRua.Text))
                enderecoParts.Add(txtRua.Text.Trim());

            if (!string.IsNullOrWhiteSpace(txtNumero.Text))
                enderecoParts.Add("nº " + txtNumero.Text.Trim());

            if (!string.IsNullOrWhiteSpace(txtBairro.Text))
                enderecoParts.Add("Bairro: " + txtBairro.Text.Trim());

            if (!string.IsNullOrWhiteSpace(txtCidade.Text))
                enderecoParts.Add("Cidade: " + txtCidade.Text.Trim());

            return string.Join(", ", enderecoParts);
        }

        private void LimparCampos()
        {
            txtNomeMae.Clear();
            txtCpfMae.Clear();
            dateTimePickerMae.Checked = false;
            txtTelMae.Clear();
            txtCelMae.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();

            _maeIdSelecionada = 0;
            _modoEdicao = false;

            dtgListMae.ClearSelection();

            // Focar no primeiro campo
            txtNomeMae.Focus();

            // Atualizar estado dos botões
            AtualizarEstadoBotoes();
        }

        private bool ValidarCampos()
        {
            // Validar campo obrigatório: Nome
            if (string.IsNullOrWhiteSpace(txtNomeMae.Text))
            {
                MessageBox.Show("Por favor, informe o nome da mãe.",
                    "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeMae.Focus();
                return false;
            }

            // Validar campo obrigatório: CPF
            if (string.IsNullOrWhiteSpace(txtCpfMae.Text))
            {
                MessageBox.Show("Por favor, informe o CPF da mãe.",
                    "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpfMae.Focus();
                return false;
            }

            // Validar CPF
            string cpfLimpo = LimparCpf(txtCpfMae.Text);
            if (!ValidarCpf(cpfLimpo))
            {
                MessageBox.Show("CPF inválido! Por favor, verifique os números digitados.",
                    "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpfMae.Focus();
                return false;
            }

            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregarMaes();
            LimparCampos();
        }
    }
}