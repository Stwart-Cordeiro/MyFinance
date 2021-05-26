using System.Collections.Generic;

namespace Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(string id);
        IEnumerable<TEntity> GetAll();
        void Dispose();
    }
}