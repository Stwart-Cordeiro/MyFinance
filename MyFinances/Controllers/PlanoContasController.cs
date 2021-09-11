using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using CrossCutting;
using Microsoft.AspNetCore.Mvc;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyFinances.ViewModels;

namespace MyFinances.Controllers
{
    [Authorize]
    public class PlanoContasController : BaseController
    {

        private readonly IApplicationServicePlanoConta _planoConta;
        private new readonly UserManager<Usuario> _userManager;

        public PlanoContasController(IApplicationServicePlanoConta planoConta, UserManager<Usuario> userManager, ILogger<PlanoContasController> logger, IApplicationServiceLogSistema logSistema)
        : base(logger, userManager, logSistema)
        {
            _planoConta = planoConta;
            _userManager = userManager;
        }


        // GET: PlanoContas
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var usuario = await _userManager.GetUserAsync(User);

            var planoConta = _planoConta.GetAll(usuario.Id);

            if (!string.IsNullOrEmpty(searchString))
            {
                planoConta = _planoConta.GetSearch(searchString, usuario.Id);
            }

            planoConta = sortOrder switch
            {
                "name_desc" => planoConta.OrderByDescending(x => x.Nome),
                _ => planoConta.OrderBy(x => x.Nome),
            };

            var pageSize = 10;

            if (_planoConta.Erro.Numero != Erro.Tipo.SemErro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, _planoConta.Erro.Mensagem);
            }

            return View(PaginatedList<PlanoContas>.Create(planoConta, pageNumber ?? 1, pageSize));
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

                if (_planoConta.Erro.Numero != Erro.Tipo.SemErro)
                {
                    await LogSistemaTask(EnumTipoLog.Erro, _planoConta.Erro.Mensagem);
                }

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

                if (_planoConta.Erro.Numero != Erro.Tipo.SemErro)
                {
                    await LogSistemaTask(EnumTipoLog.Erro, _planoConta.Erro.Mensagem);
                }

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

                if (_planoConta.Erro.Numero != Erro.Tipo.SemErro)
                {
                    await LogSistemaTask(EnumTipoLog.Erro, _planoConta.Erro.Mensagem);
                }
                else
                {
                    await LogSistemaTask(EnumTipoLog.Informativo, planoContas);
                }
            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);
            }

            return RedirectToAction(nameof(Index));
        }
        
    }
}
