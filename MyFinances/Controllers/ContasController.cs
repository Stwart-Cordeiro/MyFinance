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
    public class ContasController : BaseController
    {
        private readonly IApplicationServiceConta _service;
        private new readonly UserManager<Usuario> _userManager;

        public ContasController(IApplicationServiceConta service, UserManager<Usuario> userManager, ILogger<ContasController> logger, IApplicationServiceLogSistema logSistema)
            : base(logger, userManager, logSistema)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: Contas
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

            var contas = _service.GetAll(usuario.Id);

            if (!string.IsNullOrEmpty(searchString))
            {
                contas = _service.GetSearch(searchString, usuario.Id);
            }


            contas = sortOrder switch
            {
                "name_desc" => contas.OrderByDescending(x => x.Nome),
                _ => contas.OrderBy(x => x.Nome),
            };

            var pageSize = 10;

            if (_service.Erro.Numero != Erro.Tipo.SemErro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, _service.Erro.Mensagem);
            }

            return View(PaginatedList<Contas>.Create(contas, pageNumber ?? 1, pageSize));
        }

        // GET: Contas/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contas = _service.GetById(id);

            if (contas == null)
            {
                return NotFound();
            }

            return View(contas);
        }

        // GET: Contas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contas contas)
        {
            try
            {
                var usuario = await _userManager.GetUserAsync(User);
                contas.IdConta = Guid.NewGuid().ToString();
                contas.UserId = usuario.Id;

                _service.Add(contas);

                if (_service.Erro.Numero != Erro.Tipo.SemErro)
                {
                    await LogSistemaTask(EnumTipoLog.Erro, _service.Erro.Mensagem);
                }

                if (contas.Notificacoes.Any())
                {
                    foreach (var item in contas.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }

                    return View(contas);

                }

                await LogSistemaTask(EnumTipoLog.Informativo, contas);
            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);

                return View(contas);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Contas/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contas = _service.GetById(id);

            if (contas == null)
            {
                return NotFound();
            }

            return View(contas);
        }

        // POST: Contas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Contas contas)
        {
            if (id != contas.IdConta)
            {
                return NotFound();
            }

            try
            {
                _service.Update(contas);

                if (_service.Erro.Numero != Erro.Tipo.SemErro)
                {
                    await LogSistemaTask(EnumTipoLog.Erro, _service.Erro.Mensagem);
                }

                if (contas.Notificacoes.Any())
                {
                    foreach (var item in contas.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }

                    return View(contas);

                }

                await LogSistemaTask(EnumTipoLog.Informativo, contas);
            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);

                return View(contas);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Contas/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contas = _service.GetById(id);

            if (contas == null)
            {
                return NotFound();
            }

            return View(contas);
        }

        // POST: Contas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            try
            {
                var contas = _service.GetById(id);

                _service.Delete(contas);

                if (_service.Erro.Numero != Erro.Tipo.SemErro)
                {
                    await LogSistemaTask(EnumTipoLog.Erro, _service.Erro.Mensagem);
                                       
                }
                else
                {
                    await LogSistemaTask(EnumTipoLog.Informativo, contas);
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
