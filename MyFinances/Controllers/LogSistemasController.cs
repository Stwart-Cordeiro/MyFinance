using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace MyFinances.Controllers
{
    [Authorize]
    public class LogSistemasController : BaseController
    {

        public LogSistemasController(UserManager<Usuario> userManager,
            ILogger<ContasController> logger, IApplicationServiceLogSistema logSistema)
            : base(logger, userManager, logSistema)
        {

        }

        // GET: LogSistemas
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);

            return View(_ServiceLog.GetAll(usuario.Id));
        }

        // GET: LogSistemas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logSistema = _ServiceLog.GetById(id);

            if (logSistema == null)
            {
                return NotFound();
            }

            return View(logSistema);
        }
        
    }
}
