using System;
using System.Collections.Generic;
using System.Linq;
using CrossCutting;
using Domain.Core.Interfaces.Repositorys;
using Entities.Entities;
using Entities.Entities.Enums;
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
            try
            {
                return _myFinancesContext.PlanoConta.Where(x => x.UserId == userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public PlanoContas GetById(string id)
        {
            try
            {
                return _myFinancesContext.PlanoConta.Include(p => p.Usuario).FirstOrDefault(x => x.IdPlanoConta == id);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<PlanoContas> GetAllAtivadas(string userId)
        {
            try
            {
                return _myFinancesContext.PlanoConta.Where(x => x.UserId == userId && x.Status == EnumStatus.Ativado);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        
    }
}