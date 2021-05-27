using Application.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyFinance.Controllers
{
    
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

        [HttpGet]
        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
    }
}
