using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bercario.Models
{
    public class Bebe
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal? PesoNascimento { get; set; }
        public decimal? Altura { get; set; }
        public int IdMae { get; set; }
        public int IdMedicoParto { get; set; }
        public DateTime DataCadastro { get; set; }

        // Propriedades de navegação (opcional)
        public Mae Mae { get; set; }
        public Medico MedicoParto { get; set; }
    }
}
