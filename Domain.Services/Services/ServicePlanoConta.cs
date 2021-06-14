using System.Collections.Generic;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Domain.Services.Services
{
    public class ServicePlanoConta : ServiceBase<PlanoContas>,IServicePlanoConta
    {

        private readonly IRepositoryPlanoConta _repositoryPlanoConta;


        public ServicePlanoConta(IRepositoryPlanoConta repositoryPlanoConta) : base(repositoryPlanoConta)
        {
            _repositoryPlanoConta = repositoryPlanoConta;
        }

        public IEnumerable<PlanoContas> GetAll(string userId)
        {
            return _repositoryPlanoConta.GetAll(userId);
        }

        public PlanoContas GetById(string id)
        {
            return _repositoryPlanoConta.GetById(id);
        }
    }
}