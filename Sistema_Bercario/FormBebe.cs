using Sistema_Bercario.Models;
using Sistema_Bercario.RespositorioDao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Bercario
{
    public partial class FormBebe : Form
    {
        private BebeRepository _bebeRepository;
        private MaeRepository _maeRepository;
        private MedicoRepository _medicoRepository;
        private int _codigoBebeEdicao = 0;
        private bool _modoEdicao = false;

        // Instância de ToolTip para exibir dicas
        private ToolTip _toolTip = new ToolTip();

        public FormBebe()
        {
            InitializeComponent();
            _bebeRepository = new BebeRepository();
            _maeRepository = new MaeRepository();
            _medicoRepository = new MedicoRepository();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impede redimensionamento
            this.MaximizeBox = false; // Remove o botão maximizar
            this.MinimizeBox = true;  // Opcional: deixa o botão minimizar

            ConfigurarFormulario();
        }

        private void FormBebe_Load(object sender, EventArgs e)
        {
            CarregarListaBebes();
            LimparCampos();
        }

        private void ConfigurarFormulario()
        {
            // Configurar DateTimePicker
            dateTimePickerBebe.Format = DateTimePickerFormat.Custom;
            dateTimePickerBebe.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePickerBebe.Value = DateTime.Now;

            // Configurar eventos dos botões
            btnSalvarBebe.Click += BtnSalvarBebe_Click;
            btnLimparCampos.Click += BtnLimparCampos_Click;
            btnAtualizarBebe.Click += BtnAtualizarBebe_Click;
            btnDeletarBebe.Click += BtnDeletarBebe_Click;

            // Configurar eventos dos campos
            txtCpfMae.Leave += TxtCpfMae_Leave;
            txtCRM.Leave += TxtCRM_Leave;

            // Configurar eventos do DataGridView
            dtgListBebe.SelectionChanged += DtgListBebe_SelectionChanged;
            dtgListBebe.CellDoubleClick += DtgListBebe_CellDoubleClick;
            dtgListBebe.CellClick += DtgListBebe_CellClick;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Configurar validações
            ConfigurarValidacoesCampos();

            LimparCampos();
        }

        private void ConfigurarValidacoesCampos()
        {
            // Limitar caracteres nos campos
            txtNomeBebe.MaxLength = 100;
            txtCpfMae.MaxLength = 14;
            txtCRM.MaxLength = 20;

            // Eventos de validação
            txtPesoBebe.KeyPress += TxtNumerico_KeyPress;
            txtAlturaBebe.KeyPress += TxtNumerico_KeyPress;
        }

        private void TxtNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir números, vírgula, ponto, backspace e delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void ConfigurarDataGridView()
        {
            dtgListBebe.AutoGenerateColumns = false;
            dtgListBebe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgListBebe.MultiSelect = false;
            dtgListBebe.ReadOnly = true;
            dtgListBebe.AllowUserToAddRows = false;
            dtgListBebe.AllowUserToDeleteRows = false;

            // Limpar colunas existentes
            dtgListBebe.Columns.Clear();

            // Adicionar colunas
            dtgListBebe.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Codigo",
                HeaderText = "Código",
                DataPropertyName = "Codigo",
                Width = 80
            });

            dtgListBebe.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome do Bebê",
                DataPropertyName = "Nome",
                Width = 150
            });

            dtgListBebe.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataNascimento",
                HeaderText = "Data Nascimento",
                DataPropertyName = "DataNascimentoFormatada",
                Width = 130
            });

            dtgListBebe.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PesoNascimento",
                HeaderText = "Peso (Kg)",
                DataPropertyName = "PesoNascimento",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dtgListBebe.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Altura",
                HeaderText = "Altura (cm)",
                DataPropertyName = "Altura",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N1" }
            });

            dtgListBebe.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeMae",
                HeaderText = "Nome da Mãe",
                DataPropertyName = "NomeMae",
                Width = 150
            });

            dtgListBebe.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CpfMae",
                HeaderText = "CPF da Mãe",
                DataPropertyName = "CpfMae",
                Width = 120
            });

            dtgListBebe.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeMedico",
                HeaderText = "Médico",
                DataPropertyName = "NomeMedico",
                Width = 130
            });

            dtgListBebe.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CrmMedico",
                HeaderText = "CRM",
                DataPropertyName = "CrmMedico",
                Width = 80
            });
        }

        private void CarregarListaBebes()
        {
            try
            {
                var bebes = _bebeRepository.ListarTodos();
                var dadosParaExibicao = new List<object>();

                foreach (var bebe in bebes)
                {
                    // Buscar dados da mãe
                    var mae = _maeRepository.BuscarPorId(bebe.IdMae);
                    string nomeMae = mae?.Nome ?? "N/A";
                    string cpfMae = mae?.Cpf ?? "N/A";

                    // Buscar dados do médico
                    var medico = _medicoRepository.BuscarPorId(bebe.IdMedicoParto);
                    string nomeMedico = medico?.Nome ?? "N/A";
                    string crmMedico = medico?.Crm ?? "N/A";

                    dadosParaExibicao.Add(new
                    {
                        Codigo = bebe.Codigo,
                        Nome = bebe.Nome,
                        DataNascimentoFormatada = bebe.DataNascimento.ToString("dd/MM/yyyy HH:mm"),
                        PesoNascimento = bebe.PesoNascimento,
                        Altura = bebe.Altura,
                        NomeMae = nomeMae,
                        CpfMae = cpfMae,
                        NomeMedico = nomeMedico,
                        CrmMedico = crmMedico
                    });
                }

                dtgListBebe.DataSource = dadosParaExibicao;
                dtgListBebe.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista de bebês: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCpfMae_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCpfMae.Text))
            {
                txtCpfMae.BackColor = SystemColors.Window;
                txtCpfMae.Tag = null;
                _toolTip.SetToolTip(txtCpfMae, "");
                return;
            }

            try
            {
                // Buscar mãe pelo CPF
                var mae = _maeRepository.BuscarPorCpf(txtCpfMae.Text.Trim());

                if (mae != null)
                {
                    txtCpfMae.BackColor = Color.LightGreen;
                    txtCpfMae.Tag = mae; // Armazenar o objeto mãe

                    // Mostrar o nome da mãe em tooltip
                    _toolTip.SetToolTip(txtCpfMae, $"Mãe: {mae.Nome}");
                }
                else
                {
                    txtCpfMae.BackColor = Color.LightCoral;
                    txtCpfMae.Tag = null;
                    _toolTip.SetToolTip(txtCpfMae, "");
                    MessageBox.Show("CPF não encontrado no cadastro de mães.",
                        "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                txtCpfMae.BackColor = Color.LightCoral;
                txtCpfMae.Tag = null;
                _toolTip.SetToolTip(txtCpfMae, "");
                MessageBox.Show($"Erro ao buscar CPF: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCRM_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCRM.Text))
            {
                txtCRM.BackColor = SystemColors.Window;
                txtCRM.Tag = null;
                _toolTip.SetToolTip(txtCRM, "");
                return;
            }

            try
            {
                // Buscar médico pelo CRM
                var medicos = _medicoRepository.ListarTodos();
                var medico = medicos.FirstOrDefault(m => m.Crm.Equals(txtCRM.Text.Trim(), StringComparison.OrdinalIgnoreCase));

                if (medico != null)
                {
                    txtCRM.BackColor = Color.LightGreen;
                    txtCRM.Tag = medico; // Armazenar o objeto médico

                    // Mostrar o nome do médico em tooltip
                    _toolTip.SetToolTip(txtCRM, $"Médico: {medico.Nome}");
                }
                else
                {
                    txtCRM.BackColor = Color.LightCoral;
                    txtCRM.Tag = null;
                    _toolTip.SetToolTip(txtCRM, "");
                    MessageBox.Show("CRM não encontrado no cadastro de médicos.",
                        "CRM Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                txtCRM.BackColor = Color.LightCoral;
                txtCRM.Tag = null;
                _toolTip.SetToolTip(txtCRM, "");
                MessageBox.Show($"Erro ao buscar CRM: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalvarBebe_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                var bebe = new Bebe
                {
                    Nome = txtNomeBebe.Text.Trim(),
                    DataNascimento = dateTimePickerBebe.Value,
                    PesoNascimento = string.IsNullOrWhiteSpace(txtPesoBebe.Text) ?
                        null : decimal.Parse(txtPesoBebe.Text.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Altura = string.IsNullOrWhiteSpace(txtAlturaBebe.Text) ?
                        null : decimal.Parse(txtAlturaBebe.Text.Replace(',', '.'), CultureInfo.InvariantCulture),
                    IdMae = ((Mae)txtCpfMae.Tag).Id,
                    IdMedicoParto = ((Medico)txtCRM.Tag).Id
                };

                // Inserir novo bebê
                int codigoGerado = _bebeRepository.Inserir(bebe);
                bool sucesso = codigoGerado > 0;

                if (sucesso)
                {
                    MessageBox.Show($"Bebê cadastrado com sucesso! Código: {codigoGerado}",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarListaBebes();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar bebê. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar bebê: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtualizarBebe_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _codigoBebeEdicao == 0)
                {
                    MessageBox.Show("Selecione um bebê para atualizar!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                    return;

                var bebe = new Bebe
                {
                    Codigo = _codigoBebeEdicao,
                    Nome = txtNomeBebe.Text.Trim(),
                    DataNascimento = dateTimePickerBebe.Value,
                    PesoNascimento = string.IsNullOrWhiteSpace(txtPesoBebe.Text) ?
                        null : decimal.Parse(txtPesoBebe.Text.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Altura = string.IsNullOrWhiteSpace(txtAlturaBebe.Text) ?
                        null : decimal.Parse(txtAlturaBebe.Text.Replace(',', '.'), CultureInfo.InvariantCulture),
                    IdMae = ((Mae)txtCpfMae.Tag).Id,
                    IdMedicoParto = ((Medico)txtCRM.Tag).Id
                };

                bool sucesso = _bebeRepository.Atualizar(bebe);

                if (sucesso)
                {
                    MessageBox.Show("Bebê atualizado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarListaBebes();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar bebê. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar bebê: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeletarBebe_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _codigoBebeEdicao == 0)
                {
                    MessageBox.Show("Selecione um bebê para excluir!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Tem certeza que deseja excluir o bebê: {txtNomeBebe.Text}?\n\n" +
                    "ATENÇÃO: Esta ação não pode ser desfeita!",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    bool sucesso = _bebeRepository.Excluir(_codigoBebeEdicao);

                    if (sucesso)
                    {
                        MessageBox.Show("Bebê excluído com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                        CarregarListaBebes();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir bebê. Tente novamente.",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir bebê: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void DtgListBebe_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgListBebe.SelectedRows.Count > 0)
            {
                var linhaSelecionada = dtgListBebe.SelectedRows[0];

                if (linhaSelecionada.Cells["Codigo"].Value != null)
                {
                    int codigoSelecionado = Convert.ToInt32(linhaSelecionada.Cells["Codigo"].Value);
                    var bebe = _bebeRepository.BuscarPorCodigo(codigoSelecionado);

                    if (bebe != null)
                    {
                        PreencherCampos(bebe);
                    }
                }
            }
        }

        private void DtgListBebe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNomeBebe.Focus();
            }
        }

        private void DtgListBebe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgListBebe.Rows[e.RowIndex];

                if (row.Cells["Codigo"].Value != null)
                {
                    int codigoSelecionado = Convert.ToInt32(row.Cells["Codigo"].Value);
                    var bebe = _bebeRepository.BuscarPorCodigo(codigoSelecionado);

                    if (bebe != null)
                    {
                        PreencherCampos(bebe);
                    }
                }
            }
        }

        private void PreencherCampos(Bebe bebe)
        {
            _codigoBebeEdicao = bebe.Codigo;
            _modoEdicao = true;

            txtNomeBebe.Text = bebe.Nome ?? "";
            dateTimePickerBebe.Value = bebe.DataNascimento;
            txtPesoBebe.Text = bebe.PesoNascimento?.ToString("F0") ?? "";
            txtAlturaBebe.Text = bebe.Altura?.ToString("F1") ?? "";

            // Carregar CPF da mãe
            var mae = _maeRepository.BuscarPorId(bebe.IdMae);
            if (mae != null)
            {
                txtCpfMae.Text = mae.Cpf;
                txtCpfMae.Tag = mae;
                txtCpfMae.BackColor = Color.LightGreen;
                _toolTip.SetToolTip(txtCpfMae, $"Mãe: {mae.Nome}");
            }

            // Carregar CRM do médico
            var medico = _medicoRepository.BuscarPorId(bebe.IdMedicoParto);
            if (medico != null)
            {
                txtCRM.Text = medico.Crm;
                txtCRM.Tag = medico;
                txtCRM.BackColor = Color.LightGreen;
                _toolTip.SetToolTip(txtCRM, $"Médico: {medico.Nome}");
            }

            AtualizarEstadoBotoes();
        }

        private void AtualizarEstadoBotoes()
        {
            btnSalvarBebe.Enabled = !_modoEdicao;
            btnAtualizarBebe.Enabled = _modoEdicao;
            btnDeletarBebe.Enabled = _modoEdicao;

            btnSalvarBebe.Text = _modoEdicao ? "Salvar" : "Salvar";
            btnAtualizarBebe.Text = "Atualizar";
        }

        private void LimparCampos()
        {
            txtNomeBebe.Clear();
            txtPesoBebe.Clear();
            txtAlturaBebe.Clear();
            txtCpfMae.Clear();
            txtCRM.Clear();

            txtCpfMae.BackColor = SystemColors.Window;
            txtCRM.BackColor = SystemColors.Window;
            txtCpfMae.Tag = null;
            txtCRM.Tag = null;
            _toolTip.SetToolTip(txtCpfMae, "");
            _toolTip.SetToolTip(txtCRM, "");

            dateTimePickerBebe.Value = DateTime.Now;
            _codigoBebeEdicao = 0;
            _modoEdicao = false;

            dtgListBebe.ClearSelection();

            // Focar no primeiro campo
            txtNomeBebe.Focus();

            // Atualizar estado dos botões
            AtualizarEstadoBotoes();
        }

        private bool ValidarCampos()
        {
            // Validar campo obrigatório: Nome
            if (string.IsNullOrWhiteSpace(txtNomeBebe.Text))
            {
                MessageBox.Show("Por favor, informe o nome do bebê.",
                    "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeBebe.Focus();
                return false;
            }

            // Validar campo obrigatório: CPF da Mãe
            if (txtCpfMae.Tag == null)
            {
                MessageBox.Show("Informe um CPF válido da mãe.",
                    "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpfMae.Focus();
                return false;
            }

            // Validar campo obrigatório: CRM do Médico
            if (txtCRM.Tag == null)
            {
                MessageBox.Show("Informe um CRM válido do médico.",
                    "CRM Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCRM.Focus();
                return false;
            }

            // Validar peso se informado
            if (!string.IsNullOrWhiteSpace(txtPesoBebe.Text))
            {
                string pesoTexto = txtPesoBebe.Text.Replace(',', '.');
                if (!decimal.TryParse(pesoTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal peso) || peso <= 0)
                {
                    MessageBox.Show("Informe um peso válido (em gramas).",
                        "Peso Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPesoBebe.Focus();
                    return false;
                }
            }

            // Validar altura se informada
            if (!string.IsNullOrWhiteSpace(txtAlturaBebe.Text))
            {
                string alturaTexto = txtAlturaBebe.Text.Replace(',', '.');
                if (!decimal.TryParse(alturaTexto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal altura) || altura <= 0)
                {
                    MessageBox.Show("Informe uma altura válida (em centímetros).",
                        "Altura Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAlturaBebe.Focus();
                    return false;
                }
            }

            return true;
        }

        // Método adicional para buscar bebês (se necessário)
        public void BuscarBebes(string filtro = "")
        {
            try
            {
                List<Bebe> bebes;

                if (string.IsNullOrWhiteSpace(filtro))
                {
                    bebes = _bebeRepository.ListarTodos();
                }
                else
                {
                    bebes = _bebeRepository.BuscarPorNome(filtro);
                }

                var dadosParaExibicao = new List<object>();

                foreach (var bebe in bebes)
                {
                    // Buscar dados da mãe
                    var mae = _maeRepository.BuscarPorId(bebe.IdMae);
                    string nomeMae = mae?.Nome ?? "N/A";
                    string cpfMae = mae?.Cpf ?? "N/A";

                    // Buscar dados do médico
                    var medico = _medicoRepository.BuscarPorId(bebe.IdMedicoParto);
                    string nomeMedico = medico?.Nome ?? "N/A";
                    string crmMedico = medico?.Crm ?? "N/A";

                    dadosParaExibicao.Add(new
                    {
                        Codigo = bebe.Codigo,
                        Nome = bebe.Nome,
                        DataNascimentoFormatada = bebe.DataNascimento.ToString("dd/MM/yyyy HH:mm"),
                        PesoNascimento = bebe.PesoNascimento,
                        Altura = bebe.Altura,
                        NomeMae = nomeMae,
                        CpfMae = cpfMae,
                        NomeMedico = nomeMedico,
                        CrmMedico = crmMedico
                    });
                }

                dtgListBebe.DataSource = dadosParaExibicao;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar bebês: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregarListaBebes();
            LimparCampos();
        }
    }
}
