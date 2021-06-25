using Domain.Core.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using CrossCutting;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>,IDisposable where TEntity: class
    {

        private readonly MyFinancesContext _myFinancesContext;

        protected RepositoryBase(MyFinancesContext myFinancesContext)
        {
            _myFinancesContext = myFinancesContext;
            Erro = new Erro();
        }

        public Erro Erro { get; set; }

        public void Add(TEntity entity)
        {
            try
            {
                _myFinancesContext.Set<TEntity>().Add(entity);
                _myFinancesContext.SaveChanges();
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _myFinancesContext.Entry(entity).State = EntityState.Modified;
                _myFinancesContext.SaveChanges();
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _myFinancesContext.Set<TEntity>().Remove(entity);
                _myFinancesContext.SaveChanges();
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }
        }

        public TEntity GetById(string id)
        {
            try
            {
               return _myFinancesContext.Set<TEntity>().Find(id);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _myFinancesContext.Set<TEntity>().ToList();
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public void Dispose()
        {
            _myFinancesContext.Dispose();
        }
    }
}