using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;
using System.Collections.Generic;

namespace Domain.Services.Services
{
    public class ServiceLogSistema : ServiceBase<LogSistema>, IServiceLogSistema
    {
        private readonly IRepositoryLogSistema _repositoryLogSistema;

        public ServiceLogSistema(IRepositoryLogSistema repositoryLogSistema) : base(repositoryLogSistema)
        {
            _repositoryLogSistema = repositoryLogSistema;
        }

        public IEnumerable<LogSistema> GetAll(string userId)
        {
            return _repositoryLogSistema.GetAll(userId);
        }

        public LogSistema GetById(string id)
        {
            return _repositoryLogSistema.GetById(id);
        }
    }
}