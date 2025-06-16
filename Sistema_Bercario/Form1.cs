using System.Data;

namespace Sistema_Bercario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            DatabaseConnection db = new DatabaseConnection();

            if (db.TestarConexao())
            {
                MessageBox.Show("Conexão OK! ✅");

                // Testar uma consulta
                DataTable dados = db.ExecutarConsulta("SELECT * FROM vw_administradores");
                MessageBox.Show($"Encontrados {dados.Rows.Count} administradores");
            }
            else
            {
                MessageBox.Show("Falha na conexão! ❌");
            }
        }
    }
}
