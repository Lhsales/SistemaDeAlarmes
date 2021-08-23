using Microsoft.AspNetCore.Mvc;
using SistemaDeAlarmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Controllers
{
    public class AlarmeController : Controller
    {
        private AlarmeContext db = new AlarmeContext();
        private LogController logC = new LogController();
        public IActionResult Index()
        {
            IEnumerable<Alarme> model = new List<Alarme>();
            model = db.Alarmes.ToList().OrderBy(x => x.Equipamento.Nome);
            return View(model);
        }

        public IActionResult Registro(int? Id)
        {
            Alarme model = new Alarme();
            if (Id == null)
                

        }

    }
}
