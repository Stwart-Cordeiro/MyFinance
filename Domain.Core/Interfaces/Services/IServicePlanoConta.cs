using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Services
{
    public interface IServicePlanoConta : IServiceBase<PlanoContas>
    {
        public IEnumerable<PlanoContas> GetAll(string userId);
        public PlanoContas GetById(string id);
        public IEnumerable<PlanoContas> GetAllAtivadas(string userId);
        public IEnumerable<PlanoContas> GetSearch(string search, string userId);

    }
}