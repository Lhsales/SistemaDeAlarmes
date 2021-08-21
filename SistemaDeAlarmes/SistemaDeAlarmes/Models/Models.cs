using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SistemaDeAlarmes.Models
{
    public class Models
    {
    }

    public class AlarmeContext : DbContext
    {
        public DbSet<Alarme> Alarmes{ get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<AlarmeAtuado> AlarmesAtuados { get; set; }
        public DbSet<Log> Logs { get; set; }

        private readonly IConfiguration _config;

        public AlarmeContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_config.GetConnectionString("AlarmeConnection"));
    }
    public class Equipamento
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string NumeroSerie { get; set; }
        public TipoEquipamento Tipo { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Alarme> Alarmes { get; set; }
    }

    public class Alarme
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public ClassificacaoAlarme Classificacao { get; set; }
        public int EquipamentoID { get; set; }

        public virtual Equipamento Equipamento { get; set; }
    }

    public class AlarmeAtuado
    {
        public int ID { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public bool Status { get; set; }
        public int AlarmeID { get; set; }

        public virtual Alarme Alarme { get; set; }
    }

    public class Log
    {
        public int ID { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Descricao { get; set; }
        public string Acao { get; set; }
        public string Tabela { get; set; }
    }

    #region Enums

    public enum TipoEquipamento
    {
        Tensão, Corrente, Óleo
    }
    public enum ClassificacaoAlarme
    {
        Alto, Médio, Baixo
    }
    #endregion
}
