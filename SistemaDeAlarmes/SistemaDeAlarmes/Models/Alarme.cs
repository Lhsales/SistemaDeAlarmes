using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAlarmes.Models
{
    public class Alarme
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Descrição deve ser preenchido")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Classificação deve ser selecionada")]
        public ClassificacaoAlarme? Classificacao { get; set; }
        [Required(ErrorMessage = "Equipamento deve ser selecionado")]
        public int? EquipamentoID { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Equipamento Equipamento { get; set; }
    }
    public enum ClassificacaoAlarme
    {
        Alto, Médio, Baixo
    }
}
