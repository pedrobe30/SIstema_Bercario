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
    public class MedicoRepository
    {
        private readonly DatabaseConnection _db;

        public MedicoRepository()
        {
            _db = new DatabaseConnection();
        }

        public List<Medico> ListarTodos()
        {
            List<Medico> medicos = new List<Medico>();

            try
            {
                string sql = "SELECT * FROM medicos WHERE status_ativo = 1 ORDER BY nome";
                DataTable tabela = _db.ExecutarConsulta(sql);

                foreach (DataRow row in tabela.Rows)
                {
                    medicos.Add(new Medico
                    {
                        Id = Convert.ToInt32(row["id_medico"]),
                        Nome = row["nome"].ToString(),
                        Crm = row["crm"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        Email = row["email"].ToString(),
                        Especialidade = row["especialidade"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        StatusAtivo = Convert.ToBoolean(row["status_ativo"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar médicos: " + ex.Message);
            }

            return medicos;
        }

        public List<Medico> ListarPorEspecialidade(string especialidade)
        {
            List<Medico> medicos = new List<Medico>();

            try
            {
                string sql = "SELECT * FROM medicos WHERE especialidade = @especialidade AND status_ativo = 1 ORDER BY nome";
                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@especialidade", especialidade));

                foreach (DataRow row in tabela.Rows)
                {
                    medicos.Add(new Medico
                    {
                        Id = Convert.ToInt32(row["id_medico"]),
                        Nome = row["nome"].ToString(),
                        Crm = row["crm"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        Email = row["email"].ToString(),
                        Especialidade = row["especialidade"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        StatusAtivo = Convert.ToBoolean(row["status_ativo"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar médicos por especialidade: " + ex.Message);
            }

            return medicos;
        }

        public Medico BuscarPorId(int id)
        {
            try
            {
                string sql = "SELECT * FROM medicos WHERE id_medico = @id";
                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@id", id));

                if (tabela.Rows.Count > 0)
                {
                    DataRow row = tabela.Rows[0];
                    return new Medico
                    {
                        Id = Convert.ToInt32(row["id_medico"]),
                        Nome = row["nome"].ToString(),
                        Crm = row["crm"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        Email = row["email"].ToString(),
                        Especialidade = row["especialidade"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        StatusAtivo = Convert.ToBoolean(row["status_ativo"])
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar médico: " + ex.Message);
            }

            return null;
        }

        public bool Inserir(Medico medico)
        {
            try
            {
                string sql = @"INSERT INTO medicos (nome, crm, telefone, celular, email, especialidade) 
                          VALUES (@nome, @crm, @telefone, @celular, @email, @especialidade)";

                return _db.ExecutarComando(sql,
                    new MySqlParameter("@nome", medico.Nome),
                    new MySqlParameter("@crm", medico.Crm),
                    new MySqlParameter("@telefone", medico.Telefone ?? ""),
                    new MySqlParameter("@celular", medico.Celular ?? ""),
                    new MySqlParameter("@email", medico.Email ?? ""),
                    new MySqlParameter("@especialidade", medico.Especialidade ?? ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir médico: " + ex.Message);
                return false;
            }
        }

        public bool Atualizar(Medico medico)
        {
            try
            {
                string sql = @"UPDATE medicos SET 
                          nome = @nome, 
                          crm = @crm, 
                          telefone = @telefone, 
                          celular = @celular, 
                          email = @email, 
                          especialidade = @especialidade 
                          WHERE id_medico = @id";

                return _db.ExecutarComando(sql,
                    new MySqlParameter("@nome", medico.Nome),
                    new MySqlParameter("@crm", medico.Crm),
                    new MySqlParameter("@telefone", medico.Telefone ?? ""),
                    new MySqlParameter("@celular", medico.Celular ?? ""),
                    new MySqlParameter("@email", medico.Email ?? ""),
                    new MySqlParameter("@especialidade", medico.Especialidade ?? ""),
                    new MySqlParameter("@id", medico.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar médico: " + ex.Message);
                return false;
            }
        }

        public bool DesativarMedico(int id)
        {
            try
            {
                string sql = "UPDATE medicos SET status_ativo = 0 WHERE id_medico = @id";
                return _db.ExecutarComando(sql, new MySqlParameter("@id", id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao desativar médico: " + ex.Message);
                return false;
            }
        }

        public bool CrmJaExiste(string crm, int? idExcluir = null)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM medicos WHERE crm = @crm";
                List<MySqlParameter> parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@crm", crm)
            };

                if (idExcluir.HasValue)
                {
                    sql += " AND id_medico != @id_excluir";
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
    }


}
