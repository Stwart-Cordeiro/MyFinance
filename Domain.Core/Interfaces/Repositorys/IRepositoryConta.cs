using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryConta: IRepositoryBase<Contas>
    {
        public IEnumerable<Contas> GetAll(string userId);
    }
}