using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAlarmes.Models
{
    public enum Classificacao
    {
        Alto, Médio, Baixo
    }
    public class Alarmes
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Classificacao Classificacao { get; set; }
        public int EquipamentosId { get; set; }
        public DateTime DataCadastro{ get; set; }

        public virtual Equipamentos Equipamento { get; set; }

    }
}
