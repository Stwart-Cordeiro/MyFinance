using Domain.Core.Interfaces.Repositorys;
using Entities.Entities;
using Infrastructure.Configuration;

namespace Infrastructure.Repository
{
    public class RepositoryLogSistema: RepositoryBase<LogSistema>,IRepositoryLogSistema
    {
        private readonly MyFinancesContext _myFinancesContext;

        public RepositoryLogSistema(MyFinancesContext myFinancesContext) : base(myFinancesContext)
        {
            _myFinancesContext = myFinancesContext;
        }
    }
}