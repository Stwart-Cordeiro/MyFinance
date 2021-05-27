using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Entities.Entities.Enums;
using Newtonsoft.Json;

namespace MyFinance.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> _Logger;

        private readonly UserManager<Usuario> _UserManager;

        private readonly IApplicationServiceLogSistema _ServiceLogSistema;

        public BaseController(ILogger<BaseController> logger, UserManager<Usuario> userManager, IApplicationServiceLogSistema serviceLogSistema)
        {
            _Logger = logger;
            _UserManager = userManager;
            _ServiceLogSistema = serviceLogSistema;
        }


        public async Task LogSistemaTaskAsync(EnumTipoLog tipoLog, Object objeto)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
            
            _ServiceLogSistema.Add(new LogSistema
            {
                TipoLog = tipoLog,
                JsonInformacao = JsonConvert.SerializeObject(objeto),
                UserId = await RetornarIdUsuarioLogado(),
                NomeAction = actionName,
                NomeController = controllerName
            });
        }

        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (_UserManager == null) return string.Empty;
            var idUsuario = await _UserManager.GetUserAsync(User);
            return idUsuario != null ? idUsuario.Id : string.Empty;
        }
    }
}
