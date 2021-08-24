﻿using Microsoft.AspNetCore.Mvc;
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
            vm.alarmes = listarAlarmes();
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
            }
            catch (Exception ex)
            {
                alarmeAtuado = null;
                mensagem = "Alarme não pôde ser desativado: " + ex.Message;
            }

            return RedirectToAction("Index", new { alarmeID = alarmeAtuado.AlarmeID, mensagem = mensagem });
        }

        private List<SelectListItem> listarAlarmes()
        {
            return db.Alarmes.ToList().Where(x => x.Ativo).OrderByDescending(x => x.Descricao).Select(x => new SelectListItem() { Text = x.Descricao, Value = x.ID.ToString() }).ToList();
        }
    }
}
