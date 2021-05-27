using System;
using System.Threading.Tasks;
using Application.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyFinances.Controllers
{
    public class BaseController : Controller
    {

        public readonly ILogger<BaseController> _Logger;

        public readonly UserManager<Usuario> _userManager;

        public readonly IApplicationServiceLogSistema _ServiceLog;

        public BaseController(ILogger<BaseController> logger, UserManager<Usuario> userManager, IApplicationServiceLogSistema serviceLog)
        {
            _Logger = logger;
            _userManager = userManager;
            _ServiceLog = serviceLog;
        }

        public async Task<string> RetornarIdUsuarioLogado()
        {
            if (_userManager == null) return string.Empty;
            var idUsuario = await _userManager.GetUserAsync(User);
            return idUsuario != null ? idUsuario.Id : string.Empty;
        }

        public async Task LogSistemaTask(EnumTipoLog tipoLog, Object objeto)
        {
            var actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            var controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

            _ServiceLog.Add(new LogSistema
            {
                IdLogSistema = Guid.NewGuid().ToString(),
                TipoLog = tipoLog,
                JsonInformacao = JsonConvert.SerializeObject(objeto),
                UserId = await RetornarIdUsuarioLogado(),
                NomeAction = actionName,
                NomeController = controllerName
            });
        }
    }
}
