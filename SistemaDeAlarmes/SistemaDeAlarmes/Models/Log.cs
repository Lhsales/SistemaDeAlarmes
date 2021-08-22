using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Models
{
    public class Log
    {
        public int ID { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Descricao { get; set; }
        public string Acao { get; set; }
        public string Tabela { get; set; }
    }
}
