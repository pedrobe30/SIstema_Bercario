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
    public class AltaHospitalarRepository
    {
        private readonly DatabaseConnection _db;

        public AltaHospitalarRepository()
        {
            _db = new DatabaseConnection();
        }

        public List<AltaHospitalar> ListarTodas()
        {
            List<AltaHospitalar> altas = new List<AltaHospitalar>();

            try
            {
                string sql = @"SELECT ah.*, 
                          b.nome AS nome_bebe, 
                          m.nome AS nome_mae,
                          m.cpf AS cpf_mae,
                          med.nome AS nome_medico
                          FROM altas_hospitalares ah
                          INNER JOIN bebes b ON ah.codigo_bebe = b.codigo_bebe
                          INNER JOIN maes m ON ah.id_mae = m.id_mae
                          INNER JOIN medicos med ON ah.id_medico_alta = med.id_medico
                          ORDER BY ah.data_alta DESC, ah.hora_alta DESC";

                DataTable tabela = _db.ExecutarConsulta(sql);

                foreach (DataRow row in tabela.Rows)
                {
                    altas.Add(new AltaHospitalar
                    {
                        Id = Convert.ToInt32(row["id_alta"]),
                        CodigoBebe = Convert.ToInt32(row["codigo_bebe"]),
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoAlta = Convert.ToInt32(row["id_medico_alta"]),
                        DataAlta = Convert.ToDateTime(row["data_alta"]),
                        HoraAlta = TimeSpan.Parse(row["hora_alta"].ToString()),
                        Observacoes = row["observacoes"].ToString(),
                        DataRegistro = Convert.ToDateTime(row["data_registro"]),
                        Bebe = new Bebe { Nome = row["nome_bebe"].ToString() },
                        Mae = new Mae { 
                            Nome = row["nome_mae"].ToString(),
                            Cpf = row["cpf_mae"].ToString() 
                        },
                        MedicoAlta = new Medico { Nome = row["nome_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar altas hospitalares: " + ex.Message);
            }

            return altas;
        }

        public AltaHospitalar BuscarPorBebe(int codigoBebe)
        {
            try
            {
                string sql = @"SELECT ah.*, 
                          b.nome AS nome_bebe, 
                          m.nome AS nome_mae,
                          m.cpf AS cpf_mae,
                          med.nome AS nome_medico
                          FROM altas_hospitalares ah
                          INNER JOIN bebes b ON ah.codigo_bebe = b.codigo_bebe
                          INNER JOIN maes m ON ah.id_mae = m.id_mae
                          INNER JOIN medicos med ON ah.id_medico_alta = med.id_medico
                          WHERE ah.codigo_bebe = @codigo_bebe";

                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@codigo_bebe", codigoBebe));

                if (tabela.Rows.Count > 0)
                {
                    DataRow row = tabela.Rows[0];
                    return new AltaHospitalar
                    {
                        Id = Convert.ToInt32(row["id_alta"]),
                        CodigoBebe = Convert.ToInt32(row["codigo_bebe"]),
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoAlta = Convert.ToInt32(row["id_medico_alta"]),
                        DataAlta = Convert.ToDateTime(row["data_alta"]),
                        HoraAlta = TimeSpan.Parse(row["hora_alta"].ToString()),
                        Observacoes = row["observacoes"].ToString(),
                        DataRegistro = Convert.ToDateTime(row["data_registro"]),
                        Bebe = new Bebe { Nome = row["nome_bebe"].ToString() },
                        Mae = new Mae { 
                            Nome = row["nome_mae"].ToString(),
                            Cpf = row["cpf_mae"].ToString() 
                        },
                        MedicoAlta = new Medico { Nome = row["nome_medico"].ToString() }
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar alta por bebê: " + ex.Message);
            }

            return null;
        }

        public bool Inserir(AltaHospitalar alta)
        {
            try
            {
                string sql = @"INSERT INTO altas_hospitalares 
                          (codigo_bebe, id_mae, id_medico_alta, data_alta, hora_alta, observacoes) 
                          VALUES (@codigo_bebe, @id_mae, @id_medico_alta, @data_alta, @hora_alta, @observacoes)";

                return _db.ExecutarComando(sql,
                    new MySqlParameter("@codigo_bebe", alta.CodigoBebe),
                    new MySqlParameter("@id_mae", alta.IdMae),
                    new MySqlParameter("@id_medico_alta", alta.IdMedicoAlta),
                    new MySqlParameter("@data_alta", alta.DataAlta),
                    new MySqlParameter("@hora_alta", alta.HoraAlta),
                    new MySqlParameter("@observacoes", alta.Observacoes ?? ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir alta hospitalar: " + ex.Message);
                return false;
            }
        }

        public bool BebeJaTemAlta(int codigoBebe)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM altas_hospitalares WHERE codigo_bebe = @codigo_bebe";
                DataTable resultado = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@codigo_bebe", codigoBebe));

                return Convert.ToInt32(resultado.Rows[0][0]) > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<AltaHospitalar> ListarPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            List<AltaHospitalar> altas = new List<AltaHospitalar>();

            try
            {
                string sql = @"SELECT ah.*, 
                          b.nome AS nome_bebe, 
                          m.nome AS nome_mae,
                          m.cpf AS cpf_mae,
                          med.nome AS nome_medico
                          FROM altas_hospitalares ah
                          INNER JOIN bebes b ON ah.codigo_bebe = b.codigo_bebe
                          INNER JOIN maes m ON ah.id_mae = m.id_mae
                          INNER JOIN medicos med ON ah.id_medico_alta = med.id_medico
                          WHERE ah.data_alta BETWEEN @data_inicio AND @data_fim
                          ORDER BY ah.data_alta DESC, ah.hora_alta DESC";

                DataTable tabela = _db.ExecutarConsulta(sql,
                    new MySqlParameter("@data_inicio", dataInicio),
                    new MySqlParameter("@data_fim", dataFim));

                foreach (DataRow row in tabela.Rows)
                {
                    altas.Add(new AltaHospitalar
                    {
                        Id = Convert.ToInt32(row["id_alta"]),
                        CodigoBebe = Convert.ToInt32(row["codigo_bebe"]),
                        IdMae = Convert.ToInt32(row["id_mae"]),
                        IdMedicoAlta = Convert.ToInt32(row["id_medico_alta"]),
                        DataAlta = Convert.ToDateTime(row["data_alta"]),
                        HoraAlta = TimeSpan.Parse(row["hora_alta"].ToString()),
                        Observacoes = row["observacoes"].ToString(),
                        DataRegistro = Convert.ToDateTime(row["data_registro"]),
                        Bebe = new Bebe { Nome = row["nome_bebe"].ToString() },
                        Mae = new Mae { 
                            Nome = row["nome_mae"].ToString(),
                            Cpf = row["cpf_mae"].ToString() 
                        },
                        MedicoAlta = new Medico { Nome = row["nome_medico"].ToString() }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar altas por período: " + ex.Message);
            }

            return altas;
        }
    }
}