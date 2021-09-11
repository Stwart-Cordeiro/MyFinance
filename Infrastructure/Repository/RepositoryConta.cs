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
    public class RepositoryConta : RepositoryBase<Contas>,IRepositoryConta
    {
        private readonly MyFinancesContext _myFinancesContext;

        public RepositoryConta(MyFinancesContext myFinancesContext) : base(myFinancesContext)
        {
            _myFinancesContext = myFinancesContext;
        }

        public IEnumerable<Contas> GetAll(string userId)
        {
            try
            {
                return _myFinancesContext.Conta.Where(x => x.UserId == userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public Contas GetById(string id)
        {
            try
            {
                return _myFinancesContext.Conta.Include(c => c.Usuario).FirstOrDefault(m => m.IdConta == id);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<Contas> GetAllAtivadas(string userId)
        {
            try
            {
                return _myFinancesContext.Conta.Where(x => x.UserId == userId && x.Status == EnumStatus.Ativado);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<Contas> GetSearch(string search, string userId)
        {
            try
            {
                return _myFinancesContext.Conta.Where(x => x.Nome.Contains(search) && x.UserId == userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }
    }
}