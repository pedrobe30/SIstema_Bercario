using Sistema_Bercario.Models;
using Sistema_Bercario.RespositorioDao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Bercario
{
    public partial class FormAlta : Form
    {
        private AltaHospitalarRepository _altaRepository;
        private MaeRepository _maeRepository;
        private MedicoRepository _medicoRepository;
        private BebeRepository _bebeRepository;
        private int _idAltaEdicao = 0;
        private bool _modoEdicao = false;

        // Instância de ToolTip para exibir dicas
        private ToolTip _toolTip = new ToolTip();

        public FormAlta()
        {
            InitializeComponent();
            _altaRepository = new AltaHospitalarRepository();
            _maeRepository = new MaeRepository();
            _medicoRepository = new MedicoRepository();
            _bebeRepository = new BebeRepository();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Impede redimensionamento
            this.MaximizeBox = false; // Remove o botão maximizar
            this.MinimizeBox = true;  // Opcional: deixa o botão minimizar

            ConfigurarFormulario();
        }

        private void FormAlta_Load(object sender, EventArgs e)
        {
            CarregarListaAltas();
            CarregarComboMedicos();
            LimparCampos();
        }

        private void ConfigurarFormulario()
        {
            // Configurar DateTimePicker para data
            dateTimePickerAlta.Format = DateTimePickerFormat.Custom;
            dateTimePickerAlta.CustomFormat = "dd/MM/yyyy";
            dateTimePickerAlta.Value = DateTime.Now.Date;

            // Configurar DateTimePicker para hora
            dateTimePickerHora.Format = DateTimePickerFormat.Custom;
            dateTimePickerHora.CustomFormat = "HH:mm";
            dateTimePickerHora.ShowUpDown = true; // Permite usar spinner para horas
            dateTimePickerHora.Value = DateTime.Now;

            // Configurar eventos dos botões
            btnSalvarAlta.Click += BtnSalvarAlta_Click;
            btnLimparCampos.Click += BtnLimparCampos_Click;
            btnAtualizarAlta.Click += BtnAtualizarAlta_Click;
            btnDeletarAlta.Click += BtnDeletarAlta_Click;

            // Configurar eventos dos campos
            txtCpfMae.Leave += TxtCpfMae_Leave;
            txtCodigoBebe.Leave += TxtCodigoBebe_Leave;

            // Configurar eventos do DataGridView
            dtgListAltas.SelectionChanged += DtgListAltas_SelectionChanged;
            dtgListAltas.CellDoubleClick += DtgListAltas_CellDoubleClick;
            dtgListAltas.CellClick += DtgListAltas_CellClick;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Configurar validações
            ConfigurarValidacoesCampos();

            LimparCampos();
        }

        private void ConfigurarValidacoesCampos()
        {
            // Limitar caracteres nos campos
            txtCpfMae.MaxLength = 14;
            txtCodigoBebe.MaxLength = 10;


            // Eventos de validação
            txtCodigoBebe.KeyPress += TxtNumerico_KeyPress;
        }

        private void TxtNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, backspace e delete para código do bebê
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ConfigurarDataGridView()
        {
            dtgListAltas.AutoGenerateColumns = false;
            dtgListAltas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgListAltas.MultiSelect = false;
            dtgListAltas.ReadOnly = true;
            dtgListAltas.AllowUserToAddRows = false;
            dtgListAltas.AllowUserToDeleteRows = false;

            // Limpar colunas existentes
            dtgListAltas.Columns.Clear();

            // Adicionar colunas
            dtgListAltas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 60
            });

            dtgListAltas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodigoBebe",
                HeaderText = "Cód. Bebê",
                DataPropertyName = "CodigoBebe",
                Width = 80
            });

            dtgListAltas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeBebe",
                HeaderText = "Nome do Bebê",
                DataPropertyName = "NomeBebe",
                Width = 150
            });

            dtgListAltas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeMae",
                HeaderText = "Nome da Mãe",
                DataPropertyName = "NomeMae",
                Width = 150
            });

            dtgListAltas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CpfMae",
                HeaderText = "CPF da Mãe",
                DataPropertyName = "CpfMae",
                Width = 120
            });

            dtgListAltas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataAlta",
                HeaderText = "Data Alta",
                DataPropertyName = "DataAltaFormatada",
                Width = 100
            });

            dtgListAltas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoraAlta",
                HeaderText = "Hora Alta",
                DataPropertyName = "HoraAltaFormatada",
                Width = 90
            });

            dtgListAltas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeMedico",
                HeaderText = "Médico",
                DataPropertyName = "NomeMedico",
                Width = 150
            });

            dtgListAltas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Observacoes",
                HeaderText = "Observações",
                DataPropertyName = "Observacoes",
                Width = 200
            });
        }

        private void CarregarComboMedicos()
        {
            try
            {
                var medicos = _medicoRepository.ListarTodos();

                comboBoxMedico.DataSource = null;
                comboBoxMedico.DisplayMember = "Nome";
                comboBoxMedico.ValueMember = "Id";
                comboBoxMedico.DataSource = medicos;
                comboBoxMedico.SelectedIndex = -1; // Nenhum selecionado inicialmente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar médicos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarListaAltas()
        {
            try
            {
                var altas = _altaRepository.ListarTodas();
                var dadosParaExibicao = new List<object>();

                foreach (var alta in altas)
                {
                    dadosParaExibicao.Add(new
                    {
                        Id = alta.Id,
                        CodigoBebe = alta.CodigoBebe,
                        NomeBebe = alta.Bebe?.Nome ?? "N/A",
                        NomeMae = alta.Mae?.Nome ?? "N/A",
                        CpfMae = alta.Mae?.Cpf ?? "N/A",
                        DataAltaFormatada = alta.DataAlta.ToString("dd/MM/yyyy"),
                        HoraAltaFormatada = alta.HoraAlta.ToString(@"hh\:mm"),
                        NomeMedico = alta.MedicoAlta?.Nome ?? "N/A",
                        Observacoes = string.IsNullOrEmpty(alta.Observacoes) ? "" :
                                    (alta.Observacoes.Length > 50 ? alta.Observacoes.Substring(0, 50) + "..." : alta.Observacoes)
                    });
                }

                dtgListAltas.DataSource = dadosParaExibicao;
                dtgListAltas.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar lista de altas: {ex.Message}",
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
                    // Verificar se já existe um bebê selecionado
                    if (txtCodigoBebe.Tag != null)
                    {
                        var bebeSelecionado = (Bebe)txtCodigoBebe.Tag;

                        // Verificar se o CPF informado é da mãe do bebê selecionado
                        if (mae.Id != bebeSelecionado.IdMae)
                        {
                            txtCpfMae.BackColor = Color.LightCoral;
                            txtCpfMae.Tag = null;
                            _toolTip.SetToolTip(txtCpfMae, "");

                            // Buscar a mãe correta do bebê para mostrar na mensagem
                            var maeCorreta = _maeRepository.BuscarPorId(bebeSelecionado.IdMae);
                            string cpfCorreto = maeCorreta?.Cpf ?? "N/A";
                            string nomeCorreto = maeCorreta?.Nome ?? "N/A";

                            MessageBox.Show($"Este CPF não corresponde à mãe do bebê selecionado.\n\n" +
                                          $"CPF correto da mãe: {cpfCorreto}\n" +
                                          $"Nome da mãe: {nomeCorreto}",
                                "CPF Incompatível", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

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

        private void TxtCodigoBebe_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigoBebe.Text))
            {
                txtCodigoBebe.BackColor = SystemColors.Window;
                txtCodigoBebe.Tag = null;
                _toolTip.SetToolTip(txtCodigoBebe, "");
                return;
            }

            try
            {
                if (int.TryParse(txtCodigoBebe.Text.Trim(), out int codigoBebe))
                {
                    // Verificar se o bebê já tem alta
                    if (_altaRepository.BebeJaTemAlta(codigoBebe))
                    {
                        txtCodigoBebe.BackColor = Color.LightCoral;
                        txtCodigoBebe.Tag = null;
                        _toolTip.SetToolTip(txtCodigoBebe, "");
                        MessageBox.Show("Este bebê já possui alta hospitalar registrada.",
                            "Bebê já com Alta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Buscar bebê pelo código
                    var bebe = _bebeRepository.BuscarPorCodigo(codigoBebe);

                    if (bebe != null)
                    {
                        txtCodigoBebe.BackColor = Color.LightGreen;
                        txtCodigoBebe.Tag = bebe; // Armazenar o objeto bebê

                        // Mostrar o nome do bebê em tooltip
                        _toolTip.SetToolTip(txtCodigoBebe, $"Bebê: {bebe.Nome}");

                        // Limpar e invalidar o campo CPF da mãe para revalidação
                        if (!string.IsNullOrWhiteSpace(txtCpfMae.Text))
                        {
                            // Revalidar o CPF da mãe com o novo bebê selecionado
                            TxtCpfMae_Leave(txtCpfMae, EventArgs.Empty);
                        }
                        else
                        {
                            // Se não há CPF informado, sugerir o CPF correto
                            var maeCorreta = _maeRepository.BuscarPorId(bebe.IdMae);
                            if (maeCorreta != null)
                            {
                                MessageBox.Show($"CPF da mãe deste bebê: {maeCorreta.Cpf}\nNome: {maeCorreta.Nome}",
                                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        txtCodigoBebe.BackColor = Color.LightCoral;
                        txtCodigoBebe.Tag = null;
                        _toolTip.SetToolTip(txtCodigoBebe, "");
                        MessageBox.Show("Código do bebê não encontrado.",
                            "Código Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    txtCodigoBebe.BackColor = Color.LightCoral;
                    txtCodigoBebe.Tag = null;
                    _toolTip.SetToolTip(txtCodigoBebe, "");
                    MessageBox.Show("Informe um código válido (apenas números).",
                        "Código Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                txtCodigoBebe.BackColor = Color.LightCoral;
                txtCodigoBebe.Tag = null;
                _toolTip.SetToolTip(txtCodigoBebe, "");
                MessageBox.Show($"Erro ao buscar código do bebê: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalvarAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                var alta = new AltaHospitalar
                {
                    CodigoBebe = ((Bebe)txtCodigoBebe.Tag).Codigo,
                    IdMae = ((Mae)txtCpfMae.Tag).Id,
                    IdMedicoAlta = (int)comboBoxMedico.SelectedValue,
                    DataAlta = dateTimePickerAlta.Value.Date,
                    HoraAlta = dateTimePickerHora.Value.TimeOfDay,

                };

                bool sucesso = _altaRepository.Inserir(alta);

                if (sucesso)
                {
                    MessageBox.Show("Alta hospitalar registrada com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                    CarregarListaAltas();
                }
                else
                {
                    MessageBox.Show("Erro ao registrar alta hospitalar. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar alta: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAtualizarAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _idAltaEdicao == 0)
                {
                    MessageBox.Show("Selecione uma alta para atualizar!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarCampos())
                    return;

                MessageBox.Show("A atualização de altas hospitalares não é permitida por questões de segurança e auditoria.",
                    "Operação Não Permitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDeletarAlta_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_modoEdicao || _idAltaEdicao == 0)
                {
                    MessageBox.Show("Selecione uma alta para visualizar!",
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("A exclusão de altas hospitalares não é permitida por questões de segurança e auditoria.",
                    "Operação Não Permitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void DtgListAltas_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgListAltas.SelectedRows.Count > 0)
            {
                var linhaSelecionada = dtgListAltas.SelectedRows[0];

                if (linhaSelecionada.Cells["Id"].Value != null)
                {
                    int idSelecionado = Convert.ToInt32(linhaSelecionada.Cells["Id"].Value);
                    int codigoBebe = Convert.ToInt32(linhaSelecionada.Cells["CodigoBebe"].Value);

                    var alta = _altaRepository.BuscarPorBebe(codigoBebe);

                    if (alta != null)
                    {
                        PreencherCampos(alta);
                    }
                }
            }
        }

        private void DtgListAltas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtCodigoBebe.Focus();
            }
        }

        private void DtgListAltas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dtgListAltas.Rows[e.RowIndex];

                if (row.Cells["Id"].Value != null)
                {
                    int idSelecionado = Convert.ToInt32(row.Cells["Id"].Value);
                    int codigoBebe = Convert.ToInt32(row.Cells["CodigoBebe"].Value);

                    var alta = _altaRepository.BuscarPorBebe(codigoBebe);

                    if (alta != null)
                    {
                        PreencherCampos(alta);
                    }
                }
            }
        }

        private void PreencherCampos(AltaHospitalar alta)
        {
            _idAltaEdicao = alta.Id;
            _modoEdicao = true;

            dateTimePickerAlta.Value = alta.DataAlta;

            // Configurar hora
            DateTime horaCompleta = DateTime.Today.Add(alta.HoraAlta);
            dateTimePickerHora.Value = horaCompleta;



            // Carregar código do bebê
            var bebe = _bebeRepository.BuscarPorCodigo(alta.CodigoBebe);
            if (bebe != null)
            {
                txtCodigoBebe.Text = bebe.Codigo.ToString();
                txtCodigoBebe.Tag = bebe;
                txtCodigoBebe.BackColor = Color.LightGreen;
                _toolTip.SetToolTip(txtCodigoBebe, $"Bebê: {bebe.Nome}");
            }

            // Carregar CPF da mãe
            var mae = _maeRepository.BuscarPorId(alta.IdMae);
            if (mae != null)
            {
                txtCpfMae.Text = mae.Cpf;
                txtCpfMae.Tag = mae;
                txtCpfMae.BackColor = Color.LightGreen;
                _toolTip.SetToolTip(txtCpfMae, $"Mãe: {mae.Nome}");
            }

            // Selecionar médico
            comboBoxMedico.SelectedValue = alta.IdMedicoAlta;

            AtualizarEstadoBotoes();
        }

        private void AtualizarEstadoBotoes()
        {
            btnSalvarAlta.Enabled = !_modoEdicao;
            btnAtualizarAlta.Enabled = _modoEdicao;
            btnDeletarAlta.Enabled = _modoEdicao;

            btnSalvarAlta.Text = "Registrar Alta";
            btnAtualizarAlta.Text = _modoEdicao ? "Visualizar" : "Atualizar";
            btnDeletarAlta.Text = _modoEdicao ? "Detalhes" : "Excluir";
        }

        private void LimparCampos()
        {
            txtCodigoBebe.Clear();
            txtCpfMae.Clear();


            txtCpfMae.BackColor = SystemColors.Window;
            txtCodigoBebe.BackColor = SystemColors.Window;
            txtCpfMae.Tag = null;
            txtCodigoBebe.Tag = null;
            _toolTip.SetToolTip(txtCpfMae, "");
            _toolTip.SetToolTip(txtCodigoBebe, "");

            dateTimePickerAlta.Value = DateTime.Now.Date;
            dateTimePickerHora.Value = DateTime.Now;
            comboBoxMedico.SelectedIndex = -1;

            _idAltaEdicao = 0;
            _modoEdicao = false;

            dtgListAltas.ClearSelection();

            // Focar no primeiro campo
            txtCodigoBebe.Focus();

            // Atualizar estado dos botões
            AtualizarEstadoBotoes();
        }

        private bool ValidarCampos()
        {
            // Validar campo obrigatório: Código do Bebê
            if (txtCodigoBebe.Tag == null)
            {
                MessageBox.Show("Informe um código válido do bebê.",
                    "Código Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigoBebe.Focus();
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

            // VALIDAÇÃO CRÍTICA: Verificar se o CPF da mãe corresponde ao bebê selecionado
            var bebeSelecionado = (Bebe)txtCodigoBebe.Tag;
            var maeSelecionada = (Mae)txtCpfMae.Tag;

            if (bebeSelecionado.IdMae != maeSelecionada.Id)
            {
                var maeCorreta = _maeRepository.BuscarPorId(bebeSelecionado.IdMae);
                MessageBox.Show($"O CPF informado não corresponde à mãe do bebê selecionado.\n\n" +
                              $"Bebê: {bebeSelecionado.Nome} (Código: {bebeSelecionado.Codigo})\n" +
                              $"Mãe correta: {maeCorreta?.Nome ?? "N/A"}\n" +
                              $"CPF correto: {maeCorreta?.Cpf ?? "N/A"}",
                    "CPF Incompatível", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfMae.Focus();
                return false;
            }

            // Validar campo obrigatório: Médico
            if (comboBoxMedico.SelectedValue == null)
            {
                MessageBox.Show("Selecione o médico responsável pela alta.",
                    "Médico Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxMedico.Focus();
                return false;
            }

            // Validar data da alta (não pode ser futura)
            if (dateTimePickerAlta.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("A data da alta não pode ser superior à data atual.",
                    "Data Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerAlta.Focus();
                return false;
            }

            return true;
        }

        // Método para buscar altas por período (se necessário)
        public void BuscarAltasPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var altas = _altaRepository.ListarPorPeriodo(dataInicio, dataFim);
                var dadosParaExibicao = new List<object>();

                foreach (var alta in altas)
                {
                    dadosParaExibicao.Add(new
                    {
                        Id = alta.Id,
                        CodigoBebe = alta.CodigoBebe,
                        NomeBebe = alta.Bebe?.Nome ?? "N/A",
                        NomeMae = alta.Mae?.Nome ?? "N/A",
                        CpfMae = alta.Mae?.Cpf ?? "N/A",
                        DataAltaFormatada = alta.DataAlta.ToString("dd/MM/yyyy"),
                        HoraAltaFormatada = alta.HoraAlta.ToString(@"hh\:mm"),
                        NomeMedico = alta.MedicoAlta?.Nome ?? "N/A",
                        Observacoes = string.IsNullOrEmpty(alta.Observacoes) ? "" :
                                    (alta.Observacoes.Length > 50 ? alta.Observacoes.Substring(0, 50) + "..." : alta.Observacoes)
                    });
                }

                dtgListAltas.DataSource = dadosParaExibicao;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar altas por período: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CarregarListaAltas();
            CarregarComboMedicos();
            LimparCampos();
        }
    }
}