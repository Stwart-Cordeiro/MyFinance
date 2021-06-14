using Domain.Core.Interfaces.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public void Add(TEntity entity)
        {
            try
            {
                _myFinancesContext.Set<TEntity>().Add(entity);
                _myFinancesContext.SaveChanges();
            }
            catch (Exception erro)
            {
                throw erro;
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
                throw erro;
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
                throw erro;
            }
        }

        public TEntity GetById(string id)
        {
            return _myFinancesContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _myFinancesContext.Set<TEntity>().ToList();
        }

        public void Dispose()
        {
            _myFinancesContext.Dispose();
        }
    }
}