using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeAlarmes.Models;
using SistemaDeAlarmes.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAlarmes.Controllers
{
    public class EquipamentoController : Controller
    {
        private AlarmeContext db = new AlarmeContext();
        private LogController logC = new LogController();
        public IActionResult Index()
        {
            IEnumerable<Equipamento> model = new List<Equipamento>();
            model = db.Equipamentos.ToList().OrderBy(x => x.Nome);
            return View(model);
        }

        public IActionResult Registro(int? Id)
        {
            ViewModelRegistroEquipamento model = new ViewModelRegistroEquipamento();
            if (Id == null)
                model.acao = "Criar";
            else
            {
                model.acao = "Editar";
                Equipamento equipamento = db.Equipamentos.Find(Id);
                if (equipamento != null)
                {
                    model.equipamento = equipamento;
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro([Bind("ID", "Nome","NumeroSerie","Tipo")] Equipamento equipamento, string acao)
        {
            ViewModelVisualizacaoEquipamento vm = new ViewModelVisualizacaoEquipamento();
            try
            {
                if (ModelState.IsValid)
                {
                    if (acao == "Criar")
                    {
                        equipamento.DataCadastro = DateTime.Now;
                        db.Add(equipamento);
                        db.SaveChanges();
                        vm.mensagem = "Equipamento registrado";
                        logC.inserirLog(new Log() { Acao = "CREATE", Tabela = "EQUIPAMENTOS", Descricao = "Equipamento " + equipamento.Nome + " de ID " + equipamento.ID + " foi registrado." });
                    }
                    else
                    {
                        db.Entry(equipamento).State = EntityState.Modified;
                        db.SaveChanges();
                        vm.mensagem = "Equipamento atualizado";

                        logC.inserirLog(new Log() { Acao = "UPDATE", Tabela = "EQUIPAMENTOS", Descricao = "Equipamento " + equipamento.Nome + " de ID " + equipamento.ID + " foi atualizado." });
                    }
                }
                else
                {
                    return View(new Equipamento());
                }                
            }
            catch (Exception ex)
            {
                vm.erro = true;
                vm.mensagem = "Equipamento não pôde ser registrado: " + ex.Message;
            }
            vm.equipamento = equipamento;
            return View("Visualizacao", vm);
        }

        public IActionResult Deletar(int? Id)
        {
            ViewModelVisualizacaoEquipamento vm = new ViewModelVisualizacaoEquipamento();
            if (Id == null)
                return View("Index", db.Equipamentos.ToList().OrderBy(x => x.Nome));

            Equipamento equipamento = db.Equipamentos.Find(Id);
            if (equipamento == null)
                return View("Index", db.Equipamentos.ToList().OrderBy(x => x.Nome));
            
            List<Alarme> alarmes = db.Alarmes.Where(x => x.EquipamentoID == Id).ToList();
            if (alarmes.Count() > 0)
            {
                vm.erro = true;
                vm.mensagem = "Equipamento não pode ser removido pois possui alarmes vinculados. Por gentileza, remova os alarmes vinculados ao equipamento: " + equipamento.Nome;
                return View("Visualizacao", vm);
            }
            else
            {
                try
                {
                    db.Equipamentos.Remove(equipamento);
                    db.SaveChanges();
                    vm.mensagem = "Equipamento removido com sucesso";
                    vm.deletar = true;

                    logC.inserirLog(new Log() { Acao = "DELETE", Tabela = "EQUIPAMENTOS", Descricao = "Equipamento " + equipamento.Nome + " de ID " + equipamento.ID + " foi removido." });
                }
                catch (Exception ex)
                {
                    vm.erro = true;
                    vm.mensagem = "O equipamento não pôde ser removido: " + ex.Message;
                }
                return View("Visualizacao", vm);
            }

        }
    }
}
