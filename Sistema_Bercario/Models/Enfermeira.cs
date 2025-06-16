using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Bercario.Models
{
    public class Enfermeira
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Coren { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool StatusAtivo { get; set; }
    }
}
