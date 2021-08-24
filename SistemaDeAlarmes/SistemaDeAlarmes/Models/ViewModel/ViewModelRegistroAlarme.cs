using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SistemaDeAlarmes.Models.ViewModel
{
    public class ViewModelRegistroAlarme
    {
        public string acao { get; set; }
        public Alarme alarme { get; set; }
        public List<SelectListItem> equipamentos { get; set; }
    }
}
