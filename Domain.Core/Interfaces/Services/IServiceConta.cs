using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Services
{
    public interface IServiceConta : IServiceBase<Contas>
    {
        public IEnumerable<Contas> GetAll(string userId);
        public Contas GetById(string id);
        public IEnumerable<Contas> GetAllAtivadas(string userId);
        public IEnumerable<Contas> GetSearch(string search, string userId);

    }
}