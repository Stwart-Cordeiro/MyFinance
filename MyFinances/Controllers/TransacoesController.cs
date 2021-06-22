using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace MyFinances.Controllers
{
    [Authorize]
    public class TransacoesController : BaseController
    {

        private readonly IApplicationServiceTransacoes _serviceTransacoes;
        private readonly UserManager<Usuario> _userManager;
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
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);

            var transacao = _serviceTransacoes.GetAll(usuario.Id);

            return View(transacao);
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
            
            ViewBag.ListaTransacoes = _serviceTransacoes.GetAll(usuario.Id);

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Extrato(Transacoes transacoes)
        {
            var usuario = await _userManager.GetUserAsync(User);

            ViewBag.ContaId = new SelectList(_serviceConta.GetAllAtivadas(usuario.Id), "IdConta", "Nome");
            ViewBag.ListaTransacoes = _serviceTransacoes.GetAll(usuario.Id);
            return View();
        }

    }
}
