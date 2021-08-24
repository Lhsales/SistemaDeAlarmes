using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaDeAlarmes.Models;
using SistemaDeAlarmes.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeAlarmes.Controllers
{
    public class AlarmeAtuadoController : Controller
    {
        private AlarmeContext db = new AlarmeContext();
        private LogController logC = new LogController();

        [HttpGet]
        public IActionResult Index(int alarmeAtuadoID = 0, string mensagem = "", int alarmeID = 0)
        {
            ViewModelIndexAlarmeAtuado vm = new ViewModelIndexAlarmeAtuado();
            if (alarmeAtuadoID != 0)
                vm.alarmeAtuado = db.AlarmesAtuados.Find(alarmeAtuadoID);
            else
                vm.alarmeAtuado = null;

            if (alarmeID != 0)
                vm.alarmeSelecionado = db.Alarmes.Find(alarmeID);
            else
                vm.alarmeSelecionado = null;

            vm.mensagem = mensagem;
            vm.alarmes = listarAlarmes();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string Id)
        {
            ViewModelIndexAlarmeAtuado vm = new ViewModelIndexAlarmeAtuado();
            AlarmeAtuado alarmeAtuado = null;
            Alarme alarme = null;
            vm.alarmes = listarAlarmes(Id);
            if (Id != null)
            {
                alarme = db.Alarmes.Find(int.Parse(Id));
                alarmeAtuado = db.AlarmesAtuados.Where(x => x.Status == true).FirstOrDefault(x => x.AlarmeID == int.Parse(Id));
                if (alarmeAtuado != null)
                    alarmeAtuado.Alarme = alarme;
                
            }
            vm.alarmeSelecionado = alarme;
            vm.alarmeAtuado = alarmeAtuado;
            return View(vm);
        }

        public IActionResult Ativar(string Id)
        {
            string mensagem = "";
            if (Id == null)
                return RedirectToAction("Index");

            AlarmeAtuado alarmeAtuado = null;
            try
            {
                alarmeAtuado = new AlarmeAtuado();
                alarmeAtuado.AlarmeID = int.Parse(Id);
                alarmeAtuado.DataEntrada = DateTime.Now;
                alarmeAtuado.Status = true;
                db.AlarmesAtuados.Add(alarmeAtuado);
                db.SaveChanges();
                Alarme a = db.Alarmes.Find(int.Parse(Id));
                mensagem = "Alarme '" + a.Descricao + "' ativado com sucesso!";
                logC.inserirLog(new Log() { Acao = "CREATE", Tabela = "ALARMESATUADOS", Descricao = "Alarme '" + a.Descricao + "' de ID " + a.ID + " foi ativado." });
            }
            catch (Exception ex)
            {
                alarmeAtuado = null;
                mensagem = "Alarme não pôde ser ativado: " + ex.Message;
            }

            return RedirectToAction("Index", new { alarmeAtuadoID = alarmeAtuado.ID, mensagem = mensagem, alarmeID = alarmeAtuado.AlarmeID });
        }
        public IActionResult Desativar(string Id)
        {
            string mensagem = "";
            if (Id == null)
                return RedirectToAction("Index");

            AlarmeAtuado alarmeAtuado = null;
            try
            {
                alarmeAtuado = db.AlarmesAtuados.Find(int.Parse(Id));
                alarmeAtuado.DataSaida = DateTime.Now;
                alarmeAtuado.Status = false;
                db.Entry(alarmeAtuado).State = EntityState.Modified;
                db.SaveChanges();
                Alarme a = db.Alarmes.Find(alarmeAtuado.AlarmeID);
                mensagem = "Alarme '" + a.Descricao + "' desativado com sucesso!";
                logC.inserirLog(new Log() { Acao = "UPDATE", Tabela = "ALARMESATUADOS", Descricao = "Alarme '" + a.Descricao + "' de ID " + a.ID + " foi desativado." });
            }
            catch (Exception ex)
            {
                alarmeAtuado = null;
                mensagem = "Alarme não pôde ser desativado: " + ex.Message;
            }

            return RedirectToAction("Index", new { alarmeID = alarmeAtuado.AlarmeID, mensagem = mensagem });
        }

        private List<SelectListItem> listarAlarmes(string Id = "")
        {
            List<SelectListItem> selecao = db.Alarmes.ToList().Where(x => x.Ativo).OrderByDescending(x => x.Descricao).Select(x => new SelectListItem() { Text = x.Descricao, Value = x.ID.ToString() }).ToList();
            if (Id != "")
            {
                selecao.Find(x => x.Value == Id).Selected = true;
            }
            return selecao;
        }

        public IActionResult VerificarAlarmesAtuados()
        {
            ViewModelVerificarAlarmesAtuados vm = new ViewModelVerificarAlarmesAtuados();
            vm.alarmes = db.Alarmes.Where(x => x.Ativo).ToList();
            List<int> maisUsados = db.AlarmesAtuados.GroupBy(x => x.AlarmeID)
                                                    .OrderByDescending(x => x.Count())
                                                    .Take(3)
                                                    .Select(x => x.Key)
                                                    .ToList();
            vm.alarmesMaisUtilizados = db.Alarmes.Where(x => maisUsados.Contains(x.ID ?? default(int))).ToList();
            vm.equipamentos = db.Equipamentos.ToList();

            List<Alarme> todosAlarmesAtivos = new List<Alarme>();
            foreach (Alarme a in vm.alarmes)
            {
                AlarmeAtuado atuado = db.AlarmesAtuados.Where(x => x.AlarmeID == a.ID).OrderByDescending(x => x.ID).FirstOrDefault();
                a.AlarmeAtuado = atuado;
                todosAlarmesAtivos.Add(a);
            }
            vm.alarmesComAtuados = todosAlarmesAtivos;
            return View(vm);
        }
    }
}
