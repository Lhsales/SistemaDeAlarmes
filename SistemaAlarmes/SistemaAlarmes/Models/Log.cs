using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAlarmes.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Tabela { get; set; }
        public string Acao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
