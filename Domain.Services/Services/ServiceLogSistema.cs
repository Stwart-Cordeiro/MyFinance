using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Domain.Services.Services
{
    public class ServiceLogSistema : ServiceBase<LogSistema>, IServiceLogSistema
    {
        private readonly IRepositoryLogSistema _repositoryLogSistema;

        public ServiceLogSistema(IRepositoryLogSistema repositoryLogSistema) : base(repositoryLogSistema)
        {
            _repositoryLogSistema = repositoryLogSistema;
        }
    }
}