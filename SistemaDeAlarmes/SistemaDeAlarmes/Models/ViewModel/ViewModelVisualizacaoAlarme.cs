using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Models.ViewModel
{
    public class ViewModelVisualizacaoAlarme
    {
        public ViewModelVisualizacaoAlarme()
        {
            erro = false;
            deletar = false;
            mensagem = "";
            alarme = new Alarme();
        }
        public bool erro { get; set; }
        public string mensagem { get; set; }
        public bool deletar { get; set; }
        public Alarme alarme { get; set; }
    }
}
