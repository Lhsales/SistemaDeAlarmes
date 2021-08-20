using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAlarmes.Models
{
    public class AlarmesAtuados
    {
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public bool Status { get; set; }
        public int AlarmesId { get; set; }

        public virtual Alarmes Alarme { get; set; }
    }
}
