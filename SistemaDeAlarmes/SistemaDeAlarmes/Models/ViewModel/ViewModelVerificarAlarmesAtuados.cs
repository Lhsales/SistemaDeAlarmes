using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Models.ViewModel
{
    public class ViewModelVerificarAlarmesAtuados
    {
        public List<Alarme> alarmes { get; set; }
        public List<Alarme> alarmesComAtuados { get; set; }
        public List<Alarme> alarmesMaisUtilizados { get; set; }
        public List<Equipamento> equipamentos{ get; set; }
    }
}
