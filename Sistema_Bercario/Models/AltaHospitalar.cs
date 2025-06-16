using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bercario.Models
{
    public class AltaHospitalar
    {
        public int Id { get; set; }
        public int CodigoBebe { get; set; }
        public int IdMae { get; set; }
        public int IdMedicoAlta { get; set; }
        public DateTime DataAlta { get; set; }
        public TimeSpan HoraAlta { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataRegistro { get; set; }

        // Propriedades de navegação (opcional)
        public Bebe Bebe { get; set; }
        public Mae Mae { get; set; }
        public Medico MedicoAlta { get; set; }
    }


}
