using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using CrossCutting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyFinances.ViewModels;

namespace MyFinances.Controllers
{
    [Authorize]
    public class TransacoesController : BaseController
    {

        private readonly IApplicationServiceTransacoes _serviceTransacoes;
        private new readonly UserManager<Usuario> _userManager;
        private readonly IApplicationServicePlanoConta _servicePlanoConta;
        private readonly IApplicationServiceConta _serviceConta;

        public TransacoesController(IApplicationServiceTransacoes serviceTransacoes, UserManager<Usuario> userManager, ILogger<TransacoesController> logger, IApplicationServiceLogSistema logSistema, IApplicationServicePlanoConta servicePlanoConta, IApplicationServiceConta serviceConta)
        : base(logger, userManager, logSistema)
        {
            _serviceTransacoes = serviceTransacoes;
            _userManager = userManager;
            _servicePlanoConta = servicePlanoConta;
            _serviceConta = serviceConta;
        }

        // GET: Transações
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DescriSortParm"] = string.IsNullOrEmpty(sortOrder) ? "descri_desc" : "";
            ViewData["DataSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

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

            var transacao = _serviceTransacoes.GetAll(usuario.Id);

            if (!string.IsNullOrEmpty(searchString))
            {
                transacao = _serviceTransacoes.GetSearch(searchString, usuario.Id);
            }

            transacao = sortOrder switch
            {
                "descri_desc" => transacao.OrderByDescending(x => x.Descricao),
                "Date" => transacao.OrderBy(x => x.DataTransacao),
                "date_desc" => transacao.OrderByDescending(x => x.DataTransacao),
                _ => transacao.OrderByDescending(x => x.DataTransacao),
            };

            var pageSize = 10;

            if (_serviceTransacoes.Erro.Numero != Erro.Tipo.SemErro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, _serviceTransacoes.Erro.Mensagem);
            }

            return View(PaginatedList<Transacoes>.Create(transacao, pageNumber ?? 1, pageSize));
        }

        // GET: Transações/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacoes = _serviceTransacoes.GetById(id);

            if (transacoes == null)
            {
                return NotFound();
            }

            return View(transacoes);
        }

        // GET: Transações/Create
        public async Task<IActionResult> Create()
        {
            var usuario = await _userManager.GetUserAsync(User);

            ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome");
            ViewBag.PlanoContaId = new SelectList(_servicePlanoConta.GetAllAtivadas(usuario.Id), "IdPlanoConta", "Nome");

            return View();
        }

        // POST: Transações/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Transacoes transacoes)
        {
            var usuario = await _userManager.GetUserAsync(User);

            try
            {

                transacoes.IdTransacoes = Guid.NewGuid().ToString();
                transacoes.UserId = usuario.Id;

                _serviceTransacoes.Add(transacoes);

                if (_serviceTransacoes.Erro.Numero != Erro.Tipo.SemErro)
                {
                    await LogSistemaTask(EnumTipoLog.Erro, _serviceTransacoes.Erro.Mensagem);
                }

                if (transacoes.Notificacoes.Any())
                {
                    foreach (var item in transacoes.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade,item.Mensagem);
                    }
                    ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome",transacoes.ContaId);
                    ViewBag.PlanoContaId = new SelectList(_servicePlanoConta.GetAllAtivadas(usuario.Id), "IdPlanoConta", "Nome",transacoes.PlanoContaId);
                    return View(transacoes);
                }

                await LogSistemaTask(EnumTipoLog.Informativo, transacoes);
                
            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);
                ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome", transacoes.ContaId);
                ViewBag.PlanoContaId = new SelectList(_servicePlanoConta.GetAllAtivadas(usuario.Id), "IdPlanoConta", "Nome", transacoes.PlanoContaId);
                return View(transacoes);
            }

            return RedirectToAction(nameof(Index));
            
        }

        // GET: Transações/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            var usuario = await _userManager.GetUserAsync(User);

            if (id == null)
            {
                return NotFound();
            }

            var transacoes = _serviceTransacoes.GetById(id);

            if (transacoes == null)
            {
                return NotFound();
            }
            ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome", transacoes.ContaId);
            ViewBag.PlanoContaId = new SelectList(_servicePlanoConta.GetAllAtivadas(usuario.Id), "IdPlanoConta", "Nome", transacoes.PlanoContaId);
            return View(transacoes);
        }

        // POST: Transações/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Transacoes transacoes)
        {
            if (id != transacoes.IdTransacoes)
            {
                return NotFound();
            }

            var usuario = await _userManager.GetUserAsync(User);

            try
            {

                _serviceTransacoes.Update(transacoes);

                if (_serviceTransacoes.Erro.Numero != Erro.Tipo.SemErro)
                {
                    await LogSistemaTask(EnumTipoLog.Erro, _serviceTransacoes.Erro.Mensagem);
                }

                if (transacoes.Notificacoes.Any())
                {
                    foreach (var item in transacoes.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade,item.Mensagem);   
                    }
                    ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome", transacoes.ContaId);
                    ViewBag.PlanoContaId = new SelectList(_servicePlanoConta.GetAllAtivadas(usuario.Id), "IdPlanoConta", "Nome", transacoes.PlanoContaId);
                    return View(transacoes);
                }

                await LogSistemaTask(EnumTipoLog.Informativo, transacoes);

            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);

                return View(transacoes);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Transações/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacoes = _serviceTransacoes.GetById(id);

            if (transacoes == null)
            {
                return NotFound();
            }

            return View(transacoes);
        }

        // POST: Transações/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var transacoes = _serviceTransacoes.GetById(id);

                _serviceTransacoes.Delete(transacoes);

                await LogSistemaTask(EnumTipoLog.Informativo, transacoes);
            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);
            }

            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Extrato()
        {
            var usuario = await _userManager.GetUserAsync(User);

            ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome");
            
            ViewBag.ListaTransacoes = _serviceTransacoes.GetAllLimite10(usuario.Id);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Extrato(Transacoes transacoes)
        {
            var usuario = await _userManager.GetUserAsync(User);
            transacoes.UserId = usuario.Id;
            ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome");
            ViewBag.ListaTransacoes = _serviceTransacoes.ExtratoTransacoes(transacoes);

            if (_serviceTransacoes.Erro.Numero != Erro.Tipo.SemErro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, _serviceTransacoes.Erro.Mensagem);
            }

            return View();
        }

        // GET: Transações/ExtratoEdit/5
        public async Task<IActionResult> ExtratoEdit(string id)
        {
            var usuario = await _userManager.GetUserAsync(User);

            if (id == null)
            {
                return NotFound();
            }

            var transacoes = _serviceTransacoes.GetById(id);

            if (transacoes == null)
            {
                return NotFound();
            }
            ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome", transacoes.ContaId);
            ViewBag.PlanoContaId = new SelectList(_servicePlanoConta.GetAllAtivadas(usuario.Id), "IdPlanoConta", "Nome", transacoes.PlanoContaId);
            return View(transacoes);
        }

        // POST: Transações/ExtratoEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExtratoEdit(string id, Transacoes transacoes)
        {
            if (id != transacoes.IdTransacoes)
            {
                return NotFound();
            }

            var usuario = await _userManager.GetUserAsync(User);

            try
            {

                _serviceTransacoes.Update(transacoes);

                if (transacoes.Notificacoes.Any())
                {
                    foreach (var item in transacoes.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }
                    ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome", transacoes.ContaId);
                    ViewBag.PlanoContaId = new SelectList(_servicePlanoConta.GetAllAtivadas(usuario.Id), "IdPlanoConta", "Nome", transacoes.PlanoContaId);
                    return View(transacoes);
                }

                await LogSistemaTask(EnumTipoLog.Informativo, transacoes);

            }
            catch (Exception erro)
            {
                await LogSistemaTask(EnumTipoLog.Erro, erro);

                return View(transacoes);
            }
            ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome", transacoes.ContaId);
            return RedirectToAction(nameof(Extrato));
        }

        public IActionResult DashboardExtratos()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> ExtratoDespesas()
        {
            var usuario = await _userManager.GetUserAsync(User);

            var result = _serviceTransacoes.ExtratoDespesas(usuario.Id);

            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> ExtratoReceitas()
        {
            var usuario = await _userManager.GetUserAsync(User);

            var result = _serviceTransacoes.ExtratoReceitas(usuario.Id);

            return Json(result);
        }

    }
}
