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
            return View();
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
