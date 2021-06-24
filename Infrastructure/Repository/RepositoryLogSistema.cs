using System;
using System.Collections.Generic;
using System.Linq;
using CrossCutting;
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
            try
            {
                return _myFinancesContext.LogSistemas.Where(x => x.UserId == userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public LogSistema GetById(string id)
        {
            try
            {
                return _myFinancesContext.LogSistemas.Include(c => c.Usuario).FirstOrDefault(m => m.IdLogSistema == id);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }
    }
}