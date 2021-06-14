using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryPlanoConta : IRepositoryBase<PlanoContas>
    {
        public IEnumerable<PlanoContas> GetAll(string userId);

        public PlanoContas GetById(string id);
    }
}