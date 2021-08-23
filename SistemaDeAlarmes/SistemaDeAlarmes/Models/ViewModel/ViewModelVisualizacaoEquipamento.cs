using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Models.ViewModel
{
    public class ViewModelVisualizacaoEquipamento
    {
        public ViewModelVisualizacaoEquipamento()
        {
            erro = false;
            deletar = false;
            mensagem = "";
            equipamento = new Equipamento();
        }
        public bool erro { get; set; }
        public string mensagem { get; set; }
        public bool deletar { get; set; }
        public Equipamento equipamento { get; set; }
    }
}
