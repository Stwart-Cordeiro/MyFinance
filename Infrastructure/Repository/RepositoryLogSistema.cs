using System.Collections.Generic;
using System.Linq;
using Domain.Core.Interfaces.Repositorys;
using Entities.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RepositoryLogSistema: RepositoryBase<LogSistema>,IRepositoryLogSistema
    {
        private readonly MyFinancesContext _myFinancesContext;

        public RepositoryLogSistema(MyFinancesContext myFinancesContext) : base(myFinancesContext)
        {
            _myFinancesContext = myFinancesContext;
        }

        public IEnumerable<LogSistema> GetAll(string userId)
        {
            return _myFinancesContext.LogSistemas.Where(x => x.UserId == userId);
        }

        public LogSistema GetById(string id)
        {
            return _myFinancesContext.LogSistemas.Include(c => c.Usuario).FirstOrDefault(m => m.IdLogSistema == id);
        }
    }
}