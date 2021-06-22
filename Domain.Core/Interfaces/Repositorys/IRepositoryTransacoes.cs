using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryTransacoes : IRepositoryBase<Transacoes>
    {
        public IEnumerable<Transacoes> GetAll(string userId);

        public IEnumerable<Transacoes> GetAllLimite10(string userId);

        public Transacoes GetById(string id);
    }
}