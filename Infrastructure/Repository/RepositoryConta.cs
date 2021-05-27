using System.Collections.Generic;
using System.Linq;
using Domain.Core.Interfaces.Repositorys;
using Entities.Entities;
using Infrastructure.Configuration;

namespace Infrastructure.Repository
{
    public class RepositoryConta : RepositoryBase<Contas>,IRepositoryConta
    {
        private readonly MyFinancesContext _myFinancesContext;

        public RepositoryConta(MyFinancesContext myFinancesContext) : base(myFinancesContext)
        {
            _myFinancesContext = myFinancesContext;
        }

        public IEnumerable<Contas> GetAll(string userId)
        {
            return _myFinancesContext.Conta.Where(x => x.UserId == userId);
        }
    }
}