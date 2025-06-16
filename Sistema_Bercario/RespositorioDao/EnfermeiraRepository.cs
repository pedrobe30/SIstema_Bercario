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
    public class EnfermeiraRepository
    {
        private readonly DatabaseConnection _db;

        public EnfermeiraRepository()
        {
            _db = new DatabaseConnection();
        }

        public List<Enfermeira> ListarTodas()
        {
            List<Enfermeira> enfermeiras = new List<Enfermeira>();

            try
            {
                string sql = "SELECT * FROM enfermeiras WHERE status_ativo = 1 ORDER BY nome";
                DataTable tabela = _db.ExecutarConsulta(sql);

                foreach (DataRow row in tabela.Rows)
                {
                    enfermeiras.Add(new Enfermeira
                    {
                        Id = Convert.ToInt32(row["id_enfermeira"]),
                        Nome = row["nome"].ToString(),
                        Coren = row["coren"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        Email = row["email"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        StatusAtivo = Convert.ToBoolean(row["status_ativo"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar enfermeiras: " + ex.Message);
            }

            return enfermeiras;
        }

        public List<Enfermeira> ListarTodasIncluindoInativas()
        {
            List<Enfermeira> enfermeiras = new List<Enfermeira>();

            try
            {
                string sql = "SELECT * FROM enfermeiras ORDER BY nome";
                DataTable tabela = _db.ExecutarConsulta(sql);

                foreach (DataRow row in tabela.Rows)
                {
                    enfermeiras.Add(new Enfermeira
                    {
                        Id = Convert.ToInt32(row["id_enfermeira"]),
                        Nome = row["nome"].ToString(),
                        Coren = row["coren"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        Email = row["email"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        StatusAtivo = Convert.ToBoolean(row["status_ativo"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar enfermeiras: " + ex.Message);
            }

            return enfermeiras;
        }

        public Enfermeira BuscarPorId(int id)
        {
            try
            {
                string sql = "SELECT * FROM enfermeiras WHERE id_enfermeira = @id";
                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@id", id));

                if (tabela.Rows.Count > 0)
                {
                    DataRow row = tabela.Rows[0];
                    return new Enfermeira
                    {
                        Id = Convert.ToInt32(row["id_enfermeira"]),
                        Nome = row["nome"].ToString(),
                        Coren = row["coren"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        Email = row["email"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        StatusAtivo = Convert.ToBoolean(row["status_ativo"])
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar enfermeira: " + ex.Message);
            }

            return null;
        }

        public Enfermeira BuscarPorCoren(string coren)
        {
            try
            {
                string sql = "SELECT * FROM enfermeiras WHERE coren = @coren";
                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@coren", coren));

                if (tabela.Rows.Count > 0)
                {
                    DataRow row = tabela.Rows[0];
                    return new Enfermeira
                    {
                        Id = Convert.ToInt32(row["id_enfermeira"]),
                        Nome = row["nome"].ToString(),
                        Coren = row["coren"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        Email = row["email"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        StatusAtivo = Convert.ToBoolean(row["status_ativo"])
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar enfermeira por COREN: " + ex.Message);
            }

            return null;
        }

        public bool Inserir(Enfermeira enfermeira)
        {
            try
            {
                string sql = @"INSERT INTO enfermeiras (nome, coren, telefone, celular, email) 
                          VALUES (@nome, @coren, @telefone, @celular, @email)";

                return _db.ExecutarComando(sql,
                    new MySqlParameter("@nome", enfermeira.Nome),
                    new MySqlParameter("@coren", enfermeira.Coren),
                    new MySqlParameter("@telefone", enfermeira.Telefone ?? ""),
                    new MySqlParameter("@celular", enfermeira.Celular ?? ""),
                    new MySqlParameter("@email", enfermeira.Email ?? ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir enfermeira: " + ex.Message);
                return false;
            }
        }

        public bool Atualizar(Enfermeira enfermeira)
        {
            try
            {
                string sql = @"UPDATE enfermeiras SET 
                          nome = @nome, 
                          coren = @coren, 
                          telefone = @telefone, 
                          celular = @celular, 
                          email = @email 
                          WHERE id_enfermeira = @id";

                return _db.ExecutarComando(sql,
                    new MySqlParameter("@nome", enfermeira.Nome),
                    new MySqlParameter("@coren", enfermeira.Coren),
                    new MySqlParameter("@telefone", enfermeira.Telefone ?? ""),
                    new MySqlParameter("@celular", enfermeira.Celular ?? ""),
                    new MySqlParameter("@email", enfermeira.Email ?? ""),
                    new MySqlParameter("@id", enfermeira.Id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar enfermeira: " + ex.Message);
                return false;
            }
        }

        public bool DesativarEnfermeira(int id)
        {
            try
            {
                string sql = "UPDATE enfermeiras SET status_ativo = 0 WHERE id_enfermeira = @id";
                return _db.ExecutarComando(sql, new MySqlParameter("@id", id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao desativar enfermeira: " + ex.Message);
                return false;
            }
        }

        public bool ReativarEnfermeira(int id)
        {
            try
            {
                string sql = "UPDATE enfermeiras SET status_ativo = 1 WHERE id_enfermeira = @id";
                return _db.ExecutarComando(sql, new MySqlParameter("@id", id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao reativar enfermeira: " + ex.Message);
                return false;
            }
        }

        public bool CorenJaExiste(string coren, int? idExcluir = null)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM enfermeiras WHERE coren = @coren";
                List<MySqlParameter> parametros = new List<MySqlParameter>
            {
                new MySqlParameter("@coren", coren)
            };

                if (idExcluir.HasValue)
                {
                    sql += " AND id_enfermeira != @id_excluir";
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

        public List<Enfermeira> BuscarPorNome(string nome)
        {
            List<Enfermeira> enfermeiras = new List<Enfermeira>();

            try
            {
                string sql = "SELECT * FROM enfermeiras WHERE nome LIKE @nome AND status_ativo = 1 ORDER BY nome";
                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@nome", "%" + nome + "%"));

                foreach (DataRow row in tabela.Rows)
                {
                    enfermeiras.Add(new Enfermeira
                    {
                        Id = Convert.ToInt32(row["id_enfermeira"]),
                        Nome = row["nome"].ToString(),
                        Coren = row["coren"].ToString(),
                        Telefone = row["telefone"].ToString(),
                        Celular = row["celular"].ToString(),
                        Email = row["email"].ToString(),
                        DataCadastro = Convert.ToDateTime(row["data_cadastro"]),
                        StatusAtivo = Convert.ToBoolean(row["status_ativo"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar enfermeiras por nome: " + ex.Message);
            }

            return enfermeiras;
        }
    }
}