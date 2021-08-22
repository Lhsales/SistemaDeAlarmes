using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Models
{
    public class Alarme
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public ClassificacaoAlarme Classificacao { get; set; }
        public int EquipamentoID { get; set; }

        public virtual Equipamento Equipamento { get; set; }
    }
    public enum ClassificacaoAlarme
    {
        Alto, Médio, Baixo
    }
}
