using System.Collections.Generic;
using System.Linq;
using Domain.Core.Interfaces.Repositorys;
using Entities.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RepositoryTransacoes : RepositoryBase<Transacoes>,IRepositoryTransacoes
    {
        private readonly MyFinancesContext _myFinancesContext;

        public RepositoryTransacoes(MyFinancesContext myFinancesContext) : base(myFinancesContext)
        {
            _myFinancesContext = myFinancesContext;
        }

        public IEnumerable<Transacoes> GetAll(string userId)
        {
            return _myFinancesContext.Transacao
                .Include(t => t.Contas)
                .Include(t => t.PlanoContas)
                .Include(t => t.Usuario)
                .Where(x => x.UserId == userId);
        }

        public Transacoes GetById(string id)
        {
            return _myFinancesContext.Transacao
                .Include(t => t.Contas)
                .Include(t => t.PlanoContas)
                .Include(t => t.Usuario)
                .FirstOrDefault(x => x.IdTransacoes == id);
        }
    }
}