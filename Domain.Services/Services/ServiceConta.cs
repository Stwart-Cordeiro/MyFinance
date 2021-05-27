using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;
using System.Collections.Generic;

namespace Domain.Services.Services
{
    public class ServiceConta : ServiceBase<Contas>,IServiceConta
    {
        private readonly IRepositoryConta _repositoryConta;

        public ServiceConta(IRepositoryConta repositoryConta) : base(repositoryConta)
        {
            _repositoryConta = repositoryConta;
        }

        public IEnumerable<Contas> GetAll(string userId)
        {
            return _repositoryConta.GetAll(userId);
        }

        public Contas GetById(string id)
        {
            return _repositoryConta.GetById(id);
        }
    }
}