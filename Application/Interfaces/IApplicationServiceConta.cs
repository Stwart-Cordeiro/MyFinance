using Entities.Entities;
using System.Collections.Generic;
using CrossCutting;

namespace Application.Interfaces
{
    public interface IApplicationServiceConta
    {
        Erro Erro { get; set; }
        void Add(Contas conta);
        void Update(Contas conta);
        void Delete(Contas conta);
        Contas GetById(string id);
        IEnumerable<Contas> GetAll(string userId);
        IEnumerable<Contas> GetAllAtivadas(string userId);
        IEnumerable<Contas> GetSearch(string search, string userId);
        void Dispose();
    }
}