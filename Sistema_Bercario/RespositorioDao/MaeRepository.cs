using MySql.Data.MySqlClient;
using Sistema_Bercario.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bercario.RespositorioDao
{
    public class MaeRepository
    {
        private readonly DatabaseConnection _db;

        public MaeRepository()
        {
            _db = new DatabaseConnection();
        }

        public List<Mae> ListarTodas()
        {
            List<Mae> maes = new List<Mae>();

            try
            {
                string sql = "SELECT * FROM maes ORDER BY nome";
                DataTable tabela = _db.ExecutarConsulta(sql);

                foreach (DataRow row in tabela.Rows)
                {
                    maes.Add(new Mae
                    {
                        Id = Convert.ToInt32(row["id_mae"]),
                        Nome = row["nome"].ToString(),
                        Cpf = row["cpf"].ToString(),
                        DataNascimento = row["data_nascimento"] != DBNull.Value ?
                            Convert.ToDateTime(row["data_nascimento"]) : null,
                        Endereco = row["endereco"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar mães: " + ex.Message);
            }

            return maes;
        }

        public Mae BuscarPorId(int id)
        {
            try
            {
                string sql = "SELECT * FROM maes WHERE id_mae = @id";
                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@id", id));

                if (tabela.Rows.Count > 0)
                {
                    DataRow row = tabela.Rows[0];
                    return new Mae
                    {
                        Id = Convert.ToInt32(row["id_mae"]),
                        Nome = row["nome"].ToString(),
                        Cpf = row["cpf"].ToString(),
                        DataNascimento = row["data_nascimento"] != DBNull.Value ?
                            Convert.ToDateTime(row["data_nascimento"]) : null,
                        Endereco = row["endereco"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"])
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar mãe: " + ex.Message);
            }

            return null;
        }

        public Mae BuscarPorCpf(string cpf)
        {
            try
            {
                string sql = "SELECT * FROM maes WHERE cpf = @cpf";
                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@cpf", cpf));

                if (tabela.Rows.Count > 0)
                {
                    DataRow row = tabela.Rows[0];
                    return new Mae
                    {
                        Id = Convert.ToInt32(row["id_mae"]),
                        Nome = row["nome"].ToString(),
                        Cpf = row["cpf"].ToString(),
                        DataNascimento = row["data_nascimento"] != DBNull.Value ?
                            Convert.ToDateTime(row["data_nascimento"]) : null,
                        Endereco = row["endereco"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"])
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar mãe por CPF: " + ex.Message);
            }

            return null;
        }

        public bool Inserir(Mae mae)
        {
            try
            {
                string sql = @"INSERT INTO maes (nome, cpf, data_nascimento, endereco, telefone, celular) 
                          VALUES (@nome, @cpf, @data_nascimento, @endereco, @telefone, @celular)";

                return _db.ExecutarComando(sql,
                    new MySqlParameter("@nome", mae.Nome),
                    new MySqlParameter("@cpf", mae.Cpf),
                    new MySqlParameter("@data_nascimento", mae.DataNascimento ?? (object)DBNull.Value),
                    new MySqlParameter("@endereco", mae.Endereco ?? ""),
                    new MySqlParameter("@telefone", mae.Telefone ?? ""),
                    new MySqlParameter("@celular", mae.Celular ?? ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir mãe: " + ex.Message);
                return false;
            }
        }

        public bool Atualizar(Mae mae)
        {
            try
            {
                string sql = @"UPDATE maes SET 
                          nome = @nome, 
                          cpf = @cpf, 
                          data_nascimento = @data_nascimento, 
                          endereco = @endereco, 
                          telefone = @telefone, 
                          celular = @celular 
                          WHERE id_mae = @id";

                return _db.ExecutarComando(sql,
                    new MySqlParameter("@nome", mae.Nome),
                    new MySqlParameter("@cpf", mae.Cpf),
                    new MySqlParameter("@data_nascimento", mae.DataNascimento ?? (object)DBNull.Value),
                    new MySqlParameter("@endereco", mae.Endereco ?? ""),
                    new MySqlParameter("@telefone", mae.Telefone ?? ""),
                    new MySqlParameter("@celular", mae.Celular ?? ""),
                    new MySqlParameter("@id", mae.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar mãe: " + ex.Message);
                return false;
            }
        }

        public bool CpfJaExiste(string cpf, int? idExcluir = null)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM maes WHERE cpf = @cpf";
                List<MySqlParameter> parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@cpf", cpf)
            };

                if (idExcluir.HasValue)
                {
                    sql += " AND id_mae != @id_excluir";
                    parametros.Add(new MySqlParameter("@id_excluir", idExcluir.Value));
                }

                DataTable resultado = _db.ExecutarConsulta(sql, parametros.ToArray());
                return Convert.ToInt32(resultado.Rows[0][0]) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool PodeExcluir(int idMae)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM bebes WHERE id_mae = @id_mae";
                DataTable resultado = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@id_mae", idMae));

                int quantidadeBebes = Convert.ToInt32(resultado.Rows[0][0]);
                return quantidadeBebes == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar relacionamentos da mãe: " + ex.Message);
                return false;
            }
        }

        public bool Excluir(int idMae)
        {
            try
            {
                // Primeiro verifica se pode excluir
                if (!PodeExcluir(idMae))
                {
                    MessageBox.Show("Não é possível excluir esta mãe pois ela possui bebês cadastrados.",
                        "Exclusão não permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string sql = "DELETE FROM maes WHERE id_mae = @id_mae";
                return _db.ExecutarComando(sql,
                    new MySqlParameter("@id_mae", idMae));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir mãe: " + ex.Message);
                return false;
            }
        }
    }


}
