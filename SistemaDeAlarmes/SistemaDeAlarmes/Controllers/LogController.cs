using Microsoft.AspNetCore.Mvc;
using SistemaDeAlarmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Controllers
{
    public class LogController : Controller
    {
        private AlarmeContext db = new AlarmeContext();
        public IActionResult Index()
        {
            IEnumerable<Log> logs = db.Logs.ToList().OrderByDescending(x => x.DataCriacao);
            return View(logs);
        }

        public Log inserirLog(Log log)
        {
            log.DataCriacao = DateTime.Now;
            db.Logs.Add(log);
            db.SaveChanges();
            return log;
        }
    }
}
