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
        
    }
}