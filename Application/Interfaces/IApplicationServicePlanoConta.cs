using System.Collections.Generic;
using CrossCutting;
using Entities.Entities;

namespace Application.Interfaces
{
    public interface IApplicationServicePlanoConta
    {
        Erro Erro { get; set; }
        void Add(PlanoContas planoContas);
        void Update(PlanoContas planoContas);
        void Delete(PlanoContas planoContas);
        PlanoContas GetById(string id);
        IEnumerable<PlanoContas> GetAll(string userId);
        IEnumerable<PlanoContas> GetAllAtivadas(string userId);
        IEnumerable<PlanoContas> GetSearch(string search, string userId);
        void Dispose();
    }
}