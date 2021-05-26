using Application.Interfaces;
using Application.Service;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Services.Services;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HelpConfig
{
    public static class HelpIOC
    {
        public static void ConfigureSingleton(IServiceCollection service)
        {
            // INTERFACE E REPOSITORIO
            service.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            service.AddSingleton<IRepositoryConta, RepositoryConta>();
            service.AddSingleton<IRepositoryLogSistema, RepositoryLogSistema>();

            // INTERFACE APLICAÇÃO
            service.AddSingleton<IApplicationServiceConta, ApplicationServiceConta>();
            service.AddSingleton<IApplicationServiceLogSistema, ApplicationServiceLogSistema>();

            // SERVIÇO DOMINIO
            service.AddSingleton(typeof(IServiceBase<>), typeof(ServiceBase<>));
            service.AddSingleton<IServiceConta, ServiceConta>();
            service.AddSingleton<IServiceLogSistema, ServiceLogSistema>();
        }
    }
}