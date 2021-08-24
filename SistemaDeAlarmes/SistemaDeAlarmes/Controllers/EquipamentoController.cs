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
            return View(gerarListaEquipamentosAtivos());
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
                    model.equipamento = equipamento;
                
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
                        vm.mensagem = "Equipamento registrado.";
                        logC.inserirLog(new Log() { Acao = "CREATE", Tabela = "EQUIPAMENTOS", Descricao = "Equipamento " + equipamento.Nome + " de ID " + equipamento.ID + " foi registrado." });
                    }
                    else
                    {
                        db.Entry(equipamento).State = EntityState.Modified;
                        db.SaveChanges();
                        vm.mensagem = "Equipamento atualizado.";

                        logC.inserirLog(new Log() { Acao = "UPDATE", Tabela = "EQUIPAMENTOS", Descricao = "Equipamento " + equipamento.Nome + " de ID " + equipamento.ID + " foi atualizado." });
                    }
                }
                else
                {
                    ViewModelRegistroEquipamento vmEquip = new ViewModelRegistroEquipamento();
                    vmEquip.equipamento = new Equipamento();
                    vmEquip.acao = acao;
                    return View(vmEquip);
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
                return View("Index", gerarListaEquipamentosAtivos());

            Equipamento equipamento = db.Equipamentos.Find(Id);
            if (equipamento == null)
                return View("Index", gerarListaEquipamentosAtivos());
            
            List<Alarme> alarmes = db.Alarmes.Where(x => x.EquipamentoID == Id && x.Ativo).ToList();
            if (alarmes.Count() > 0)
            {
                vm.erro = true;
                vm.mensagem = "Equipamento não pode ser desativado pois possui alarmes vinculados. Por gentileza, desative os alarmes vinculados ao equipamento: " + equipamento.Nome + ".";
                return View("Visualizacao", vm);
            }
            else
            {
                try
                {
                    equipamento.Ativo = false;
                    db.Entry(equipamento).State = EntityState.Modified;
                    db.SaveChanges();
                    vm.mensagem = "Equipamento desativado com sucesso.";
                    vm.deletar = true;

                    logC.inserirLog(new Log() { Acao = "UPDATE", Tabela = "EQUIPAMENTOS", Descricao = "Equipamento " + equipamento.Nome + " de ID " + equipamento.ID + " foi desativado." });
                }
                catch (Exception ex)
                {
                    vm.erro = true;
                    vm.mensagem = "O equipamento não pôde ser desativado: " + ex.Message;
                }
                return View("Visualizacao", vm);
            }

        }

        public IEnumerable<Equipamento> gerarListaEquipamentosAtivos()
        {
            return db.Equipamentos.ToList().Where(x => x.Ativo).OrderBy(x => x.Nome);
        } 
    }
}
