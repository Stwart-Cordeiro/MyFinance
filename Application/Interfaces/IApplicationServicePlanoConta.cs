using System.Collections.Generic;
using Entities.Entities;

namespace Application.Interfaces
{
    public interface IApplicationServicePlanoConta
    {
        void Add(PlanoContas planoContas);
        void Update(PlanoContas planoContas);
        void Delete(PlanoContas planoContas);
        PlanoContas GetById(string id);
        IEnumerable<PlanoContas> GetAll(string userId);
        IEnumerable<PlanoContas> GetAllAtivadas(string userId);
        void Dispose();
    }
}