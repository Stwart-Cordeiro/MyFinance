using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MyFinances.ViewModels;
using System.Linq;

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
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DataErroSortParm"] = string.IsNullOrEmpty(sortOrder) ? "Date_desc" : "";

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

            var log = _ServiceLog.GetAll(usuario.Id);

            log = sortOrder switch
            {
                "Date_desc" => log.OrderBy(x => x.DataErro),
                _ => log.OrderByDescending(x => x.DataErro),
            };

            var pageSize = 10;

            return View(PaginatedList<LogSistema>.Create(log, pageNumber ?? 1, pageSize));
        }

        // GET: LogSistemas/Details/5
        public IActionResult Details(string id)
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
