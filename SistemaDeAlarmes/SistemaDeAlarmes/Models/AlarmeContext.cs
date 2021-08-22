using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SistemaDeAlarmes.Models
{
    public class AlarmeContext : DbContext
    {
        public DbSet<Alarme> Alarmes { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<AlarmeAtuado> AlarmesAtuados { get; set; }
        public DbSet<Log> Logs { get; set; }


        public AlarmeContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            options.UseSqlServer(configuration.GetConnectionString("AlarmeConnection"));
        }
    }
}
