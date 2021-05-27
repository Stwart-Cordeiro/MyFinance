using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace MyFinances.Controllers
{
    [Authorize]
    public class ContasController : BaseController
    {
        private readonly IApplicationServiceConta _service;
        private readonly UserManager<Usuario> _userManager;

        public ContasController(IApplicationServiceConta service, UserManager<Usuario> userManager, ILogger<ContasController> logger, IApplicationServiceLogSistema logSistema)
            : base(logger, userManager, logSistema)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: Contas
        public IActionResult Index()
        {
            var myFinancesContext = _service.GetAll();
            return View(myFinancesContext);
        }

        // GET: Contas/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var contas = await _context.Conta
        //        .Include(c => c.Usuario)
        //        .FirstOrDefaultAsync(m => m.IdConta == id);
        //    if (contas == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(contas);
        //}

        // GET: Contas/Create
        //public IActionResult Create()
        //{
        //    ViewData["UserId"] = new SelectList(_context.Usuario, "Id", "Id");
        //    return View();
        //}

        // POST: Contas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("IdConta,Nome,Status,TipoDespesas,UserId,DataCadastro,DataAlteracao")] Contas contas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(contas);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Usuario, "Id", "Id", contas.UserId);
        //    return View(contas);
        //}

        // GET: Contas/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var contas = await _context.Conta.FindAsync(id);
        //    if (contas == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Usuario, "Id", "Id", contas.UserId);
        //    return View(contas);
        //}

        // POST: Contas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("IdConta,Nome,Status,TipoDespesas,UserId,DataCadastro,DataAlteracao")] Contas contas)
        //{
        //    if (id != contas.IdConta)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(contas);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ContasExists(contas.IdConta))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Usuario, "Id", "Id", contas.UserId);
        //    return View(contas);
        //}

        // GET: Contas/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var contas = await _context.Conta
        //        .Include(c => c.Usuario)
        //        .FirstOrDefaultAsync(m => m.IdConta == id);
        //    if (contas == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(contas);
        //}

        // POST: Contas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var contas = await _context.Conta.FindAsync(id);
        //    _context.Conta.Remove(contas);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ContasExists(string id)
        //{
        //    return _context.Conta.Any(e => e.IdConta == id);
        //}
    }
}
