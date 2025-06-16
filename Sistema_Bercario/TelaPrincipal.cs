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
    public partial class TelaPrincipal : Form
    {
        private Models.Administrador adminLogado;

        public TelaPrincipal(Models.Administrador adminLogado)
        {
            InitializeComponent();
            this.adminLogado = adminLogado;
        }

        // Navegação para FormMedico
        private void btnMedicosNavegation_Click(object sender, EventArgs e)
        {
            try
            {
                FormMedico formMedico = new FormMedico();
                formMedico.Show();
                // Opcional: Ocultar a tela principal
                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o formulário de Médicos: {ex.Message}",
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navegação para FormEnfermeira
        private void btnEnfermeirasNavegation_Click(object sender, EventArgs e)
        {
            try
            {
                FormEnfermeira formEnfermeira = new FormEnfermeira();
                formEnfermeira.Show();
                // Opcional: Ocultar a tela principal
                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o formulário de Enfermeiras: {ex.Message}",
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navegação para FormBebe
        private void btnBebesNavegation_Click(object sender, EventArgs e)
        {
            try
            {
                FormBebe formBebe = new FormBebe();
                formBebe.Show();
                // Opcional: Ocultar a tela principal
                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o formulário de Bebês: {ex.Message}",
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navegação para FormMãe
        private void btnMaeNavegation_Click(object sender, EventArgs e)
        {
            try
            {
                FormMãe formMae = new FormMãe();
                formMae.Show();
                // Opcional: Ocultar a tela principal
                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o formulário de Mães: {ex.Message}",
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navegação para FormAlta
        private void btnAltaNavegation_Click(object sender, EventArgs e)
        {
            try
            {
                FormAlta formAlta = new FormAlta();
                formAlta.Show();
                // Opcional: Ocultar a tela principal
                // this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir o formulário de Alta: {ex.Message}",
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Mantendo os métodos existentes
        private void button1_Click(object sender, EventArgs e)
        {
            // Implementar funcionalidade conforme necessário
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Implementar funcionalidade conforme necessário
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Implementar funcionalidade conforme necessário
        }

        // Método opcional para fechar a aplicação
        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente sair do sistema?",
                                                "Confirmar Saída",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}