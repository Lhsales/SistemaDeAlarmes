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
            return View(gerarIndexViewModel());
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
            List<SelectListItem> equipamentos = db.Equipamentos.Where(x => x.Ativo)
                                                               .OrderBy(x => x.Nome)
                                                               .Select(x => new SelectListItem() { Text = x.Nome, Value = x.ID.ToString() }).ToList();
            model.equipamentos = equipamentos;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro([Bind("ID", "Descricao", "Classificacao", "EquipamentoID")] Alarme alarme, string acao)
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
                        vm.mensagem = "Alarme registrado.";
                        alarme.Equipamento = db.Equipamentos.Find(alarme.EquipamentoID);
                        logC.inserirLog(new Log() { Acao = "CREATE", Tabela = "ALARMES", Descricao = "Alarme '" + alarme.Descricao + "' de ID " + alarme.ID + " foi registrado." });
                    }
                    else
                    {
                        db.Entry(alarme).State = EntityState.Modified;
                        db.SaveChanges();
                        vm.mensagem = "Alarme atualizado.";
                        alarme.Equipamento = db.Equipamentos.Find(alarme.EquipamentoID);
                        logC.inserirLog(new Log() { Acao = "UPDATE", Tabela = "ALARMES", Descricao = "Alarme '" + alarme.Descricao + "' de ID " + alarme.ID + " foi atualizado." });
                    }
                }
                else
                {
                    ViewModelRegistroAlarme vmAlarme = new ViewModelRegistroAlarme();
                    vmAlarme.alarme = new Alarme();
                    vmAlarme.acao = acao;
                    List<SelectListItem> equipamentos = db.Equipamentos.OrderBy(x => x.Nome)
                                                               .Select(x => new SelectListItem() { Text = x.Nome, Value = x.ID.ToString() }).ToList();
                    vmAlarme.equipamentos = equipamentos;
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

        public IActionResult Deletar(int? Id)
        {
            ViewModelVisualizacaoAlarme vm = new ViewModelVisualizacaoAlarme();
            if (Id == null)
                return View("Index", gerarIndexViewModel());
            

            Alarme alarme = db.Alarmes.Find(Id);
            if (alarme == null) 
                return View("Index", gerarIndexViewModel());
            

            try
            {
                alarme.Ativo = false;
                db.Entry(alarme).State = EntityState.Modified;
                db.SaveChanges(); 
                
                logC.inserirLog(new Log() { Acao = "UPDATE", Tabela = "ALARMES", Descricao = "Alarme '" + alarme.Descricao + "' de ID " + alarme.ID + " foi desativado." });

                vm.mensagem = "Alarme desativado com sucesso.";
                vm.deletar = true;
            }
            catch (Exception ex)
            {
                vm.erro = true;
                vm.mensagem = "Alarme não pôde ser desativado: " + ex.Message;
            }
            return View("Visualizacao", vm);
        }

        public ViewModelIndexAlarme gerarIndexViewModel()
        {
            ViewModelIndexAlarme vmIndex = new ViewModelIndexAlarme();
            IEnumerable<Alarme> alarmes = db.Alarmes.ToList().Where(x => x.Ativo).OrderByDescending(x => x.DataCadastro);
            IEnumerable<Equipamento> equipamentos = db.Equipamentos.ToList().Where(x => x.Ativo);
            vmIndex.alarmes = alarmes;
            vmIndex.equipamentos = equipamentos;
            return vmIndex;
        }
    }
}
