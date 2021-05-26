using Application.Interfaces;
using Application.Service;
using Autofac;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Domain.Services.Services;
using Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace HelpConfig
{
    public static class HelpIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application

            builder.RegisterType<ApplicationServiceConta>().As<IApplicationServiceConta>();
            builder.RegisterType<ApplicationServiceLogSistema>().As<IApplicationServiceLogSistema>();

            #endregion

            #region IOC Services

            builder.RegisterType<ServiceConta>().As<IServiceConta>();
            builder.RegisterType<ServiceLogSistema>().As<IServiceLogSistema>();

            #endregion

            #region IOC Repositorys MySQL

            builder.RegisterType<RepositoryConta>().As<IRepositoryConta>();
            builder.RegisterType<RepositoryLogSistema>().As<IRepositoryLogSistema>();

            #endregion

            #endregion

        }
    }
}