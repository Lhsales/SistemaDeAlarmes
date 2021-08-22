using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Models
{
    public class AlarmeAtuado
    {
        public int ID { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public bool Status { get; set; }
        public int AlarmeID { get; set; }

        public virtual Alarme Alarme { get; set; }
    }
}
