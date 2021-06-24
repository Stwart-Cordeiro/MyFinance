using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryTransacoes : IRepositoryBase<Transacoes>
    {
        public IEnumerable<Transacoes> GetAll(string userId);

        public Transacoes GetById(string id);

        public IEnumerable<Transacoes> GetAllLimite10(string userId);

        public IEnumerable<Transacoes> ExtratoTransacoes(Transacoes transacoes);

        public IEnumerable<Dashboard> ExtratoDespesas(string userId);
        public IEnumerable<Dashboard> ExtratoReceitas(string userId);
    }
}