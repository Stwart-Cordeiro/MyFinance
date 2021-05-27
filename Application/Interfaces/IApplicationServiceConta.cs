using Entities.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IApplicationServiceConta
    {
        void Add(Contas conta);
        void Update(Contas conta);
        void Delete(Contas conta);
        Contas GetById(string id);
        IEnumerable<Contas> GetAll(string userId);
        void Dispose();
    }
}