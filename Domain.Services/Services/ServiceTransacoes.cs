using System.Collections.Generic;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Domain.Services.Services
{
    public class ServiceTransacoes : ServiceBase<Transacoes>,IServiceTransacoes
    {
        private readonly IRepositoryTransacoes _repositoryTransacoes;

        public ServiceTransacoes(IRepositoryTransacoes repositoryTransacoes) : base(repositoryTransacoes)
        {
            _repositoryTransacoes = repositoryTransacoes;
        }

        public IEnumerable<Transacoes> GetAll(string userId)
        {
            return _repositoryTransacoes.GetAll(userId);
        }

        public Transacoes GetById(string id)
        {
            return _repositoryTransacoes.GetById(id);
        }

        public IEnumerable<Transacoes> GetAllLimite10(string userId)
        {
            return _repositoryTransacoes.GetAll(userId);
        }
    }
}