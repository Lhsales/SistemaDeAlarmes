using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAlarmes.Models
{
    public enum Tipo
    {
        Tensão, Corrente, Óleo
    }
    public class Equipamentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumeroSerie { get; set; }
        public Tipo Tipo { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Alarmes> Alarmes { get; set; }

    }
}
