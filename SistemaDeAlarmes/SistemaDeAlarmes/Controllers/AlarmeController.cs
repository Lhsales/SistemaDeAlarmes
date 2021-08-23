using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeAlarmes.Models;
using SistemaDeAlarmes.Models.ViewModel;
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
            ViewModelRegistroAlarme model = new ViewModelRegistroAlarme();
            if (Id == null)
                model.acao = "Criar";
            else
            {
                model.acao = "Editar";
                Alarme alarme = db.Alarmes.Find(Id);
                if (alarme != null)
                    model.alarme = alarme;
            }
            SelectListItem valorDefault = new SelectListItem()
            {
                Value = "0",
                Text = "Selecione o equipamento"
            };
            IEnumerable<SelectListItem> equipamentos = new List<SelectListItem>();
            equipamentos.Concat(new[] { valorDefault });
            equipamentos.Concat(db.Equipamentos.ToList()
                                        .OrderBy(x => x.Nome)
                                        .Select(x => new SelectListItem() { Text = x.Nome, Value = x.ID.ToString() }));
            
            model.equipamentos = equipamentos;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro([Bind("ID", "Descricao", "EquipamentoID")] Alarme alarme, string acao)
        {
            ViewModelVisualizacaoAlarme vm = new ViewModelVisualizacaoAlarme();
            try
            {
                if (ModelState.IsValid)
                {
                    if (acao == "Criar")
                    {
                        alarme.DataCadastro = DateTime.Now;
                        db.Add(alarme);
                        db.SaveChanges();
                        vm.mensagem = "Alarme registrado";
                        logC.inserirLog(new Log() { Acao = "CREATE", Tabela = "ALARMES", Descricao = "Alarme para o equipamento " + alarme.Equipamento.Nome + " de ID " + alarme.ID + " foi registrado." });
                    }
                    else
                    {
                        db.Entry(alarme).State = EntityState.Modified;
                        db.SaveChanges();
                        vm.mensagem = "Equipamento atualizado";

                        logC.inserirLog(new Log() { Acao = "UPDATE", Tabela = "ALARMES", Descricao = "Alarme para o equipamento  " + alarme.Equipamento.Nome + " de ID " + alarme.ID + " foi atualizado." });
                    }
                }
                else
                {
                    ViewModelRegistroAlarme vmAlarme = new ViewModelRegistroAlarme();
                    vmAlarme.alarme = new Alarme();
                    return View(vmAlarme);
                }
            }
            catch (Exception ex)
            {
                vm.erro = true;
                vm.mensagem = "Alarme não pôde ser registrado: " + ex.Message;
            }
            vm.alarme = alarme;
            return View("Visualizacao", vm);
        }

    }
}
