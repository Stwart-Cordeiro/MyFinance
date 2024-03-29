﻿using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryConta: IRepositoryBase<Contas>
    {
        public IEnumerable<Contas> GetAll(string userId);
        public new Contas GetById(string id);
        public IEnumerable<Contas> GetAllAtivadas(string userId);
        public IEnumerable<Contas> GetSearch(string search, string userId);

    }
}