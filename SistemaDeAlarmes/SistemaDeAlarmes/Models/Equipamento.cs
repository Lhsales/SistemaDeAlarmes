using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Models
{
    public class Equipamento
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento Tipo { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Alarme> Alarmes { get; set; }
    }
    public enum TipoEquipamento
    {
        Tensão, Corrente, Óleo
    }
}
