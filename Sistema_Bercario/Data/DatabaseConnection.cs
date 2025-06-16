using MySql.Data.MySqlClient;
using System.Data;

public class DatabaseConnection
{
    private string connectionString =
        "Server=localhost;" +
        "Database=hospital_bercario;" +
        "Uid=root;" +
        "Pwd=root30;" +
        "Port=3306;";

    public bool TestarConexao()
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                return true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro na conexão: " + ex.Message);
            return false;
        }
    }

    // Executar consultas que retornam dados (SELECT)
    public DataTable ExecutarConsulta(string sql, params MySqlParameter[] parametros)
    {
        DataTable tabela = new DataTable();

        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(tabela);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro na consulta: " + ex.Message);
        }

        return tabela;
    }

    // Executar comandos que não retornam dados (INSERT, UPDATE, DELETE)
    public bool ExecutarComando(string sql, params MySqlParameter[] parametros)
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                int linhasAfetadas = cmd.ExecuteNonQuery();
                return linhasAfetadas > 0;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao executar comando: " + ex.Message);
            return false;
        }
    }

    // Obter o último ID inserido
    public int ObterUltimoId(string sql, params MySqlParameter[] parametros)
    {
        try
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                cmd.ExecuteNonQuery();

                // Obter o último ID inserido
                cmd.CommandText = "SELECT LAST_INSERT_ID()";
                cmd.Parameters.Clear();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao obter último ID: " + ex.Message);
            return 0;
        }
    }
}