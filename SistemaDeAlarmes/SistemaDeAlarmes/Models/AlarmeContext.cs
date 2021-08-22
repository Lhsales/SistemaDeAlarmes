using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Models
{
    public class AlarmeContext : DbContext
    {
        public DbSet<Alarme> Alarmes { get; set; }
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
}
