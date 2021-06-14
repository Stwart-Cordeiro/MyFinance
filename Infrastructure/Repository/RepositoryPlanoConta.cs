using System.Collections.Generic;
using System.Linq;
using Domain.Core.Interfaces.Repositorys;
using Entities.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RepositoryPlanoConta : RepositoryBase<PlanoContas>,IRepositoryPlanoConta
    {
        private readonly MyFinancesContext _myFinancesContext;

        public RepositoryPlanoConta(MyFinancesContext myFinancesContext) : base(myFinancesContext)
        {
            _myFinancesContext = myFinancesContext;
        }

        public IEnumerable<PlanoContas> GetAll(string userId)
        {
            return _myFinancesContext.PlanoConta.Where(x => x.UserId == userId);
        }

        public PlanoContas GetById(string id)
        {
            return _myFinancesContext.PlanoConta.Include(p => p.Usuario).FirstOrDefault(x => x.IdPlanoConta == id);
        }
    }
}