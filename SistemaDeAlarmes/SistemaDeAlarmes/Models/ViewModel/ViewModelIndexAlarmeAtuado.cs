using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaDeAlarmes.Models.ViewModel
{
    public class ViewModelIndexAlarmeAtuado
    {
        public List<SelectListItem> alarmes { get; set; }
        public AlarmeAtuado alarmeAtuado { get; set; }
        public Alarme alarmeSelecionado { get; set; }
        public string mensagem { get; set; }
    }
}
