using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Models.ViewModel
{
    public class ViewModelIndexAlarme
    {
        public IEnumerable<Alarme> alarmes { get; set; }
        public IEnumerable<Equipamento> equipamentos { get; set; }
    }
}
