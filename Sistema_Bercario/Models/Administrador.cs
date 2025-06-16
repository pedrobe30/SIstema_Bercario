using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bercario.Models
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string CodHosp { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
