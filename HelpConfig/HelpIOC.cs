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

        public static void ConfigureSingleton(IServiceCollection services)
        {
            // INTERFACE E REPOSITORIO
            services.AddScoped<IRepositoryConta, RepositoryConta>();
            services.AddScoped<IRepositoryLogSistema, RepositoryLogSistema>();
            services.AddScoped<IRepositoryPlanoConta, RepositoryPlanoConta>();
            services.AddScoped<IRepositoryTransacoes, RepositoryTransacoes>();

            // INTERFACE APLICAÇÃO
            services.AddScoped<IApplicationServiceConta, ApplicationServiceConta>();
            services.AddScoped<IApplicationServiceLogSistema, ApplicationServiceLogSistema>();
            services.AddScoped<IApplicationServicePlanoConta, ApplicationServicePlanoConta>();
            services.AddScoped<IApplicationServiceTransacoes, ApplicationServiceTransacoes>();

            // SERVIÇO DOMINIO
            services.AddScoped<IServiceConta, ServiceConta>();
            services.AddScoped<IServiceLogSistema, ServiceLogSistema>();
            services.AddScoped<IServicePlanoConta, ServicePlanoConta>();
            services.AddScoped<IServiceTransacoes, ServiceTransacoes>();
        }
    }
}