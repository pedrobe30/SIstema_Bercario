using MySql.Data.MySqlClient;
using Sistema_Bercario.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Bercario.RespositorioDao
{
    public class BebeRepository
    {
        private readonly DatabaseConnection _db;

        public BebeRepository()
        {
            _db = new DatabaseConnection();
        }

        public List<Bebe> ListarTodos()
        {
            List<Bebe> bebes = new List<Bebe>();

            try
            {
                string sql = @"SELECT b.*, m.nome AS nome_mae, med.nome AS nome_medico, med.crm AS crm_medico
                              FROM bebes b
                              INNER JOIN maes m ON b.id_mae = m.id_mae
                              INNER JOIN medicos med ON b.id_medico_parto = med.id_medico
                              ORDER BY b.data_nascimento DESC";

                DataTable tabela = _db.ExecutarConsulta(sql);

                foreach (DataRow row in tabela.Rows)
                {
                    bebes.Add(new Bebe
                    {
                        Codigo = Convert.ToInt32(row["codigo_bebe"]),
                        Nome = row["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(row["data_nascimento"]),
                        PesoNascimento = row["peso_nascimento"] != DBNull.Value ?
                            Convert.ToDecimal(row["peso_nascimento"]) : null,
                        Altura = row["altura"] != DBNull.Value ?
                            Convert.ToDecimal(row["altura"]) : null,
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoParto = Convert.ToInt32(row["id_medico_parto"]),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        Mae = new Mae { Nome = row["nome_mae"].ToString() },
                        MedicoParto = new Medico { Nome = row["nome_medico"].ToString(), Crm = row["crm_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar bebês: " + ex.Message);
            }

            return bebes;
        }

        public List<Bebe> ListarSemAlta()
        {
            List<Bebe> bebes = new List<Bebe>();

            try
            {
                string sql = @"SELECT b.*, m.nome AS nome_mae, med.nome AS nome_medico, med.crm AS crm_medico
                              FROM bebes b
                              INNER JOIN maes m ON b.id_mae = m.id_mae
                              INNER JOIN medicos med ON b.id_medico_parto = med.id_medico
                              LEFT JOIN altas_hospitalares ah ON b.codigo_bebe = ah.codigo_bebe
                              WHERE ah.codigo_bebe IS NULL
                              ORDER BY b.data_nascimento DESC";

                DataTable tabela = _db.ExecutarConsulta(sql);

                foreach (DataRow row in tabela.Rows)
                {
                    bebes.Add(new Bebe
                    {
                        Codigo = Convert.ToInt32(row["codigo_bebe"]),
                        Nome = row["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(row["data_nascimento"]),
                        PesoNascimento = row["peso_nascimento"] != DBNull.Value ?
                            Convert.ToDecimal(row["peso_nascimento"]) : null,
                        Altura = row["altura"] != DBNull.Value ?
                            Convert.ToDecimal(row["altura"]) : null,
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoParto = Convert.ToInt32(row["id_medico_parto"]),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        Mae = new Mae { Nome = row["nome_mae"].ToString() },
                        MedicoParto = new Medico { Nome = row["nome_medico"].ToString(), Crm = row["crm_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar bebês sem alta: " + ex.Message);
            }

            return bebes;
        }

        public List<Bebe> ListarComAlta()
        {
            List<Bebe> bebes = new List<Bebe>();

            try
            {
                string sql = @"SELECT b.*, m.nome AS nome_mae, med.nome AS nome_medico, med.crm AS crm_medico,
                              ah.data_alta, ah.hora_alta
                              FROM bebes b
                              INNER JOIN maes m ON b.id_mae = m.id_mae
                              INNER JOIN medicos med ON b.id_medico_parto = med.id_medico
                              INNER JOIN altas_hospitalares ah ON b.codigo_bebe = ah.codigo_bebe
                              ORDER BY ah.data_alta DESC, ah.hora_alta DESC";

                DataTable tabela = _db.ExecutarConsulta(sql);

                foreach (DataRow row in tabela.Rows)
                {
                    bebes.Add(new Bebe
                    {
                        Codigo = Convert.ToInt32(row["codigo_bebe"]),
                        Nome = row["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(row["data_nascimento"]),
                        PesoNascimento = row["peso_nascimento"] != DBNull.Value ?
                            Convert.ToDecimal(row["peso_nascimento"]) : null,
                        Altura = row["altura"] != DBNull.Value ?
                            Convert.ToDecimal(row["altura"]) : null,
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoParto = Convert.ToInt32(row["id_medico_parto"]),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        Mae = new Mae { Nome = row["nome_mae"].ToString() },
                        MedicoParto = new Medico { Nome = row["nome_medico"].ToString(), Crm = row["crm_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar bebês com alta: " + ex.Message);
            }

            return bebes;
        }

        public Bebe BuscarPorCodigo(int codigo)
        {
            try
            {
                string sql = @"SELECT b.*, m.nome AS nome_mae, m.cpf AS cpf_mae, 
                              med.nome AS nome_medico, med.crm AS crm_medico
                              FROM bebes b
                              INNER JOIN maes m ON b.id_mae = m.id_mae
                              INNER JOIN medicos med ON b.id_medico_parto = med.id_medico
                              WHERE b.codigo_bebe = @codigo";

                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@codigo", codigo));

                if (tabela.Rows.Count > 0)
                {
                    DataRow row = tabela.Rows[0];
                    return new Bebe
                    {
                        Codigo = Convert.ToInt32(row["codigo_bebe"]),
                        Nome = row["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(row["data_nascimento"]),
                        PesoNascimento = row["peso_nascimento"] != DBNull.Value ?
                            Convert.ToDecimal(row["peso_nascimento"]) : null,
                        Altura = row["altura"] != DBNull.Value ?
                            Convert.ToDecimal(row["altura"]) : null,
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoParto = Convert.ToInt32(row["id_medico_parto"]),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        Mae = new Mae
                        {
                            Nome = row["nome_mae"].ToString(),
                            Cpf = row["cpf_mae"].ToString()
                        },
                        MedicoParto = new Medico
                        {
                            Nome = row["nome_medico"].ToString(),
                            Crm = row["crm_medico"].ToString()
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar bebê: " + ex.Message);
            }

            return null;
        }

        public List<Bebe> BuscarPorMae(int idMae)
        {
            List<Bebe> bebes = new List<Bebe>();

            try
            {
                string sql = @"SELECT b.*, m.nome AS nome_mae, med.nome AS nome_medico, med.crm AS crm_medico
                              FROM bebes b
                              INNER JOIN maes m ON b.id_mae = m.id_mae
                              INNER JOIN medicos med ON b.id_medico_parto = med.id_medico
                              WHERE b.id_mae = @id_mae
                              ORDER BY b.data_nascimento DESC";

                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@id_mae", idMae));

                foreach (DataRow row in tabela.Rows)
                {
                    bebes.Add(new Bebe
                    {
                        Codigo = Convert.ToInt32(row["codigo_bebe"]),
                        Nome = row["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(row["data_nascimento"]),
                        PesoNascimento = row["peso_nascimento"] != DBNull.Value ?
                            Convert.ToDecimal(row["peso_nascimento"]) : null,
                        Altura = row["altura"] != DBNull.Value ?
                            Convert.ToDecimal(row["altura"]) : null,
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoParto = Convert.ToInt32(row["id_medico_parto"]),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        Mae = new Mae { Nome = row["nome_mae"].ToString() },
                        MedicoParto = new Medico { Nome = row["nome_medico"].ToString(), Crm = row["crm_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar bebês por mãe: " + ex.Message);
            }

            return bebes;
        }

        public List<Bebe> BuscarPorNome(string nome)
        {
            List<Bebe> bebes = new List<Bebe>();

            try
            {
                string sql = @"SELECT b.*, m.nome AS nome_mae, med.nome AS nome_medico, med.crm AS crm_medico
                              FROM bebes b
                              INNER JOIN maes m ON b.id_mae = m.id_mae
                              INNER JOIN medicos med ON b.id_medico_parto = med.id_medico
                              WHERE b.nome LIKE @nome
                              ORDER BY b.data_nascimento DESC";

                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@nome", "%" + nome + "%"));

                foreach (DataRow row in tabela.Rows)
                {
                    bebes.Add(new Bebe
                    {
                        Codigo = Convert.ToInt32(row["codigo_bebe"]),
                        Nome = row["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(row["data_nascimento"]),
                        PesoNascimento = row["peso_nascimento"] != DBNull.Value ?
                            Convert.ToDecimal(row["peso_nascimento"]) : null,
                        Altura = row["altura"] != DBNull.Value ?
                            Convert.ToDecimal(row["altura"]) : null,
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoParto = Convert.ToInt32(row["id_medico_parto"]),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        Mae = new Mae { Nome = row["nome_mae"].ToString() },
                        MedicoParto = new Medico { Nome = row["nome_medico"].ToString(), Crm = row["crm_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar bebês por nome: " + ex.Message);
            }

            return bebes;
        }

        public List<Bebe> BuscarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            List<Bebe> bebes = new List<Bebe>();

            try
            {
                string sql = @"SELECT b.*, m.nome AS nome_mae, med.nome AS nome_medico, med.crm AS crm_medico
                              FROM bebes b
                              INNER JOIN maes m ON b.id_mae = m.id_mae
                              INNER JOIN medicos med ON b.id_medico_parto = med.id_medico
                              WHERE DATE(b.data_nascimento) BETWEEN @data_inicio AND @data_fim
                              ORDER BY b.data_nascimento DESC";

                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@data_inicio", dataInicio.Date),
                    new MySqlParameter("@data_fim", dataFim.Date));

                foreach (DataRow row in tabela.Rows)
                {
                    bebes.Add(new Bebe
                    {
                        Codigo = Convert.ToInt32(row["codigo_bebe"]),
                        Nome = row["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(row["data_nascimento"]),
                        PesoNascimento = row["peso_nascimento"] != DBNull.Value ?
                            Convert.ToDecimal(row["peso_nascimento"]) : null,
                        Altura = row["altura"] != DBNull.Value ?
                            Convert.ToDecimal(row["altura"]) : null,
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoParto = Convert.ToInt32(row["id_medico_parto"]),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        Mae = new Mae { Nome = row["nome_mae"].ToString() },
                        MedicoParto = new Medico { Nome = row["nome_medico"].ToString(), Crm = row["crm_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar bebês por período: " + ex.Message);
            }

            return bebes;
        }

        public List<Bebe> BuscarPorMedico(int idMedico)
        {
            List<Bebe> bebes = new List<Bebe>();

            try
            {
                string sql = @"SELECT b.*, m.nome AS nome_mae, med.nome AS nome_medico, med.crm AS crm_medico
                              FROM bebes b
                              INNER JOIN maes m ON b.id_mae = m.id_mae
                              INNER JOIN medicos med ON b.id_medico_parto = med.id_medico
                              WHERE b.id_medico_parto = @id_medico
                              ORDER BY b.data_nascimento DESC";

                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@id_medico", idMedico));

                foreach (DataRow row in tabela.Rows)
                {
                    bebes.Add(new Bebe
                    {
                        Codigo = Convert.ToInt32(row["codigo_bebe"]),
                        Nome = row["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(row["data_nascimento"]),
                        PesoNascimento = row["peso_nascimento"] != DBNull.Value ?
                            Convert.ToDecimal(row["peso_nascimento"]) : null,
                        Altura = row["altura"] != DBNull.Value ?
                            Convert.ToDecimal(row["altura"]) : null,
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoParto = Convert.ToInt32(row["id_medico_parto"]),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        Mae = new Mae { Nome = row["nome_mae"].ToString() },
                        MedicoParto = new Medico { Nome = row["nome_medico"].ToString(), Crm = row["crm_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar bebês por médico: " + ex.Message);
            }

            return bebes;
        }

        public int Inserir(Bebe bebe)
        {
            try
            {
                string sql = @"INSERT INTO bebes (nome, data_nascimento, peso_nascimento, altura, id_mae, id_medico_parto) 
                              VALUES (@nome, @data_nascimento, @peso, @altura, @id_mae, @id_medico)";

                return _db.ObterUltimoId(sql,
                    new MySqlParameter("@nome", bebe.Nome),
                    new MySqlParameter("@data_nascimento", bebe.DataNascimento),
                    new MySqlParameter("@peso", bebe.PesoNascimento ?? (object)DBNull.Value),
                    new MySqlParameter("@altura", bebe.Altura ?? (object)DBNull.Value),
                    new MySqlParameter("@id_mae", bebe.IdMae),
                    new MySqlParameter("@id_medico", bebe.IdMedicoParto));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir bebê: " + ex.Message);
                return 0;
            }
        }

        public bool Atualizar(Bebe bebe)
        {
            try
            {
                string sql = @"UPDATE bebes SET 
                              nome = @nome, 
                              data_nascimento = @data_nascimento,
                              peso_nascimento = @peso,
                              altura = @altura,
                              id_mae = @id_mae,
                              id_medico_parto = @id_medico
                              WHERE codigo_bebe = @codigo";

                return _db.ExecutarComando(sql,
                    new MySqlParameter("@nome", bebe.Nome),
                    new MySqlParameter("@data_nascimento", bebe.DataNascimento),
                    new MySqlParameter("@peso", bebe.PesoNascimento ?? (object)DBNull.Value),
                    new MySqlParameter("@altura", bebe.Altura ?? (object)DBNull.Value),
                    new MySqlParameter("@id_mae", bebe.IdMae),
                    new MySqlParameter("@id_medico", bebe.IdMedicoParto),
                    new MySqlParameter("@codigo", bebe.Codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar bebê: " + ex.Message);
                return false;
            }
        }

        public bool Excluir(int codigo)
        {
            try
            {
                // Verifica se o bebê já tem alta registrada antes de excluir
                string sqlVerifica = "SELECT COUNT(*) FROM altas_hospitalares WHERE codigo_bebe = @codigo";
                DataTable resultado = _db.ExecutarConsulta(sqlVerifica, new MySqlParameter("@codigo", codigo));

                if (Convert.ToInt32(resultado.Rows[0][0]) > 0)
                {
                    MessageBox.Show("Não é possível excluir bebê que já possui alta hospitalar registrada.");
                    return false;
                }

                string sql = "DELETE FROM bebes WHERE codigo_bebe = @codigo";
                return _db.ExecutarComando(sql, new MySqlParameter("@codigo", codigo));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir bebê: " + ex.Message);
                return false;
            }
        }

        public bool TemAlta(int codigoBebe)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM altas_hospitalares WHERE codigo_bebe = @codigo";
                DataTable resultado = _db.ExecutarConsulta(sql, new MySqlParameter("@codigo", codigoBebe));
                return Convert.ToInt32(resultado.Rows[0][0]) > 0;
            }
            catch
            {
                return false;
            }
        }

        public int ContarBebesTotais()
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM bebes";
                DataTable resultado = _db.ExecutarConsulta(sql);
                return Convert.ToInt32(resultado.Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }

        public int ContarBebesSemAlta()
        {
            try
            {
                string sql = @"SELECT COUNT(*) FROM bebes b 
                              LEFT JOIN altas_hospitalares ah ON b.codigo_bebe = ah.codigo_bebe 
                              WHERE ah.codigo_bebe IS NULL";
                DataTable resultado = _db.ExecutarConsulta(sql);
                return Convert.ToInt32(resultado.Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }

        public int ContarBebesComAlta()
        {
            try
            {
                string sql = @"SELECT COUNT(*) FROM bebes b 
                              INNER JOIN altas_hospitalares ah ON b.codigo_bebe = ah.codigo_bebe";
                DataTable resultado = _db.ExecutarConsulta(sql);
                return Convert.ToInt32(resultado.Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }

        public Dictionary<string, int> ObterEstatisticasPorMes(int ano)
        {
            Dictionary<string, int> estatisticas = new Dictionary<string, int>();

            try
            {
                string sql = @"SELECT MONTH(data_nascimento) as mes, COUNT(*) as total
                              FROM bebes 
                              WHERE YEAR(data_nascimento) = @ano
                              GROUP BY MONTH(data_nascimento)
                              ORDER BY MONTH(data_nascimento)";

                DataTable tabela = _db.ExecutarConsulta(sql, new MySqlParameter("@ano", ano));

                // Inicializa todos os meses com 0
                string[] meses = { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun",
                                  "Jul", "Ago", "Set", "Out", "Nov", "Dez" };
                for (int i = 0; i < meses.Length; i++)
                {
                    estatisticas[meses[i]] = 0;
                }

                // Preenche com os dados reais
                foreach (DataRow row in tabela.Rows)
                {
                    int mes = Convert.ToInt32(row["mes"]);
                    int total = Convert.ToInt32(row["total"]);
                    estatisticas[meses[mes - 1]] = total;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter estatísticas por mês: " + ex.Message);
            }

            return estatisticas;
        }

        public List<Bebe> BuscarBebesRecemNascidos(int dias = 7)
        {
            List<Bebe> bebes = new List<Bebe>();

            try
            {
                string sql = @"SELECT b.*, m.nome AS nome_mae, med.nome AS nome_medico, med.crm AS crm_medico
                              FROM bebes b
                              INNER JOIN maes m ON b.id_mae = m.id_mae
                              INNER JOIN medicos med ON b.id_medico_parto = med.id_medico
                              WHERE DATE(b.data_nascimento) >= DATE_SUB(CURDATE(), INTERVAL @dias DAY)
                              ORDER BY b.data_nascimento DESC";

                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@dias", dias));

                foreach (DataRow row in tabela.Rows)
                {
                    bebes.Add(new Bebe
                    {
                        Codigo = Convert.ToInt32(row["codigo_bebe"]),
                        Nome = row["nome"].ToString(),
                        DataNascimento = Convert.ToDateTime(row["data_nascimento"]),
                        PesoNascimento = row["peso_nascimento"] != DBNull.Value ?
                            Convert.ToDecimal(row["peso_nascimento"]) : null,
                        Altura = row["altura"] != DBNull.Value ?
                            Convert.ToDecimal(row["altura"]) : null,
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoParto = Convert.ToInt32(row["id_medico_parto"]),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        Mae = new Mae { Nome = row["nome_mae"].ToString() },
                        MedicoParto = new Medico { Nome = row["nome_medico"].ToString(), Crm = row["crm_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar bebês recém-nascidos: " + ex.Message);
            }

            return bebes;
        }
    }
}