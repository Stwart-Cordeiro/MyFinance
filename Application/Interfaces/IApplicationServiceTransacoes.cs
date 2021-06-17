using System.Collections.Generic;
using CrossCutting;
using Entities.Entities;

namespace Application.Interfaces
{
    public interface IApplicationServiceTransacoes
    {
        Erro Erro { get; set; }
        void Add(Transacoes transacoes);
        void Update(Transacoes transacoes);
        void Delete(Transacoes transacoes);
        Transacoes GetById(string id);
        IEnumerable<Transacoes> GetAll(string userId);
        void Dispose();
    }
}