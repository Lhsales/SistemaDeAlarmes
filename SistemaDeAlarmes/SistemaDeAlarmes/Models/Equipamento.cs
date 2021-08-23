using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAlarmes.Models
{
    public class Equipamento
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Nome deve ser preenchido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Número de Série deve ser preenchido")]
        public string NumeroSerie { get; set; }
        [Required(ErrorMessage = "Tipo deve ser selecionado")]
        public TipoEquipamento? Tipo { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Alarme> Alarmes { get; set; }
    }
    public enum TipoEquipamento
    {
        Tensão, Corrente, Óleo
    }
}
