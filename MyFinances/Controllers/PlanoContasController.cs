using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace MyFinances.Controllers
{
    [Authorize]
    public class PlanoContasController : BaseController
    {

        private readonly IApplicationServicePlanoConta _planoConta;
        private readonly UserManager<Usuario> _userManager;

        public PlanoContasController(IApplicationServicePlanoConta planoConta, UserManager<Usuario> userManager, ILogger<PlanoContasController> logger, IApplicationServiceLogSistema logSistema)
        : base(logger, userManager, logSistema)
        {
            _planoConta = planoConta;
            _userManager = userManager;
        }


        // GET: PlanoContas
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);

            var planoConta = _planoConta.GetAll(usuario.Id);

            return View(planoConta);
        }

        // GET: PlanoContas/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoContas = _planoConta.GetById(id);

            if (planoContas == null)
            {
                return NotFound();
            }

            return View(planoContas);
        }

        // GET: PlanoContas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanoContas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanoContas planoContas)
        {
            try
            {
                var usuario = await _userManager.GetUserAsync(User);

                planoContas.IdPlanoConta = Guid.NewGuid().ToString();
                planoContas.UserId = usuario.Id;

                _planoConta.Add(planoContas);

                if (planoContas.Notificacoes.Any())
                {
                    foreach (var item in planoContas.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }

                    return View(planoContas);
                }

                await LogSistemaTask(EnumTipoLog.Informativo, planoContas);
            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);

                return View(planoContas);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: PlanoContas/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoContas = _planoConta.GetById(id);

            if (planoContas == null)
            {
                return NotFound();
            }

            return View(planoContas);
        }

        // POST: PlanoContas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, PlanoContas planoContas)
        {
            if (id != planoContas.IdPlanoConta)
            {
                return NotFound();
            }

            try
            {
                _planoConta.Update(planoContas);

                if (planoContas.Notificacoes.Any())
                {
                    foreach (var item in planoContas.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade,item.Mensagem);
                    }

                    return View(planoContas);
                }

                await LogSistemaTask(EnumTipoLog.Informativo, planoContas);
            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);

                return View(planoContas);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: PlanoContas/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoContas = _planoConta.GetById(id);

            if (planoContas == null)
            {
                return NotFound();
            }

            return View(planoContas);
        }

        // POST: PlanoContas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var planoContas = _planoConta.GetById(id);

                _planoConta.Delete(planoContas);

                await LogSistemaTask(EnumTipoLog.Informativo, planoContas);
            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);
            }

            return RedirectToAction(nameof(Index));
        }
        
    }
}
