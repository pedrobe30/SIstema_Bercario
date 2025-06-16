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
    public class AdministradorRepository
    {
        private readonly DatabaseConnection _db;

        public AdministradorRepository()
        {
            _db = new DatabaseConnection();
        }

        public bool ValidarLogin(string usuario, string senha)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM administradores WHERE usuario = @usuario AND senha = @senha";
                DataTable resultado = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@usuario", usuario),
                    new MySqlParameter("@senha", senha));

                return Convert.ToInt32(resultado.Rows[0][0]) > 0;
            }
            catch
            {
                return false;
            }
        }

        public Administrador BuscarPorUsuario(string usuario)
        {
            try
            {
                string sql = "SELECT * FROM administradores WHERE usuario = @usuario";
                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@usuario", usuario));

                if (tabela.Rows.Count > 0)
                {
                    DataRow row = tabela.Rows[0];
                    return new Administrador
                    {
                        Id = Convert.ToInt32(row["id_admin"]),
                        Usuario = row["usuario"].ToString(),
                        CodHosp = row["cod_hosp"].ToString(),
                        Senha = row["senha"].ToString(),
                        DataCriacao = Convert.ToDateTime(row["data_criacao"])
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar administrador: " + ex.Message);
            }

            return null;
        }

        public List<Administrador> ListarTodos()
        {
            List<Administrador> administradores = new List<Administrador>();

            try
            {
                string sql = "SELECT * FROM administradores ORDER BY usuario";
                DataTable tabela = _db.ExecutarConsulta(sql);

                foreach (DataRow row in tabela.Rows)
                {
                    administradores.Add(new Administrador
                    {
                        Id = Convert.ToInt32(row["id_admin"]),
                        Usuario = row["usuario"].ToString(),
                        CodHosp = row["cod_hosp"].ToString(),
                        // Não retornamos a senha por segurança
                        DataCriacao = Convert.ToDateTime(row["data_criacao"])
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar administradores: " + ex.Message);
            }

            return administradores;
        }

        public bool CriarAdministrador(Administrador admin)
        {
            try
            {
                string sql = @"INSERT INTO administradores (usuario, cod_hosp, senha) 
                          VALUES (@usuario, @cod_hosp, @senha)";

                return _db.ExecutarComando(sql,
                    new MySqlParameter("@usuario", admin.Usuario),
                    new MySqlParameter("@cod_hosp", admin.CodHosp),
                    new MySqlParameter("@senha", admin.Senha));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar administrador: " + ex.Message);
                return false;
            }
        }

        public bool AlterarSenha(string usuario, string novaSenha)
        {
            try
            {
                string sql = "UPDATE administradores SET senha = @nova_senha WHERE usuario = @usuario";
                return _db.ExecutarComando(sql,
                    new MySqlParameter("@nova_senha", novaSenha),
                    new MySqlParameter("@usuario", usuario));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar senha: " + ex.Message);
                return false;
            }
        }

        public bool UsuarioJaExiste(string usuario)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM administradores WHERE usuario = @usuario";
                DataTable resultado = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@usuario", usuario));

                return Convert.ToInt32(resultado.Rows[0][0]) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool ExcluirAdministrador(int id)
        {
            try
            {
                string sql = "DELETE FROM administradores WHERE id_admin = @id";
                return _db.ExecutarComando(sql, new MySqlParameter("@id", id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir administrador: " + ex.Message);
                return false;
            }
        }
    }
}
