using System.Collections.Generic;
using System.Linq;
using Domain.Core.Interfaces.Repositorys;
using Entities.Entities;
using Entities.Entities.Enums;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

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

        public Contas GetById(string id)
        {
            return _myFinancesContext.Conta.Include(c => c.Usuario).FirstOrDefault(m => m.IdConta == id);
        }

        public IEnumerable<Contas> GetAllAtivadas(string userId)
        {
            return _myFinancesContext.Conta.Where(x => x.UserId == userId && x.Status == EnumStatus.Ativado);
        }
    }
}