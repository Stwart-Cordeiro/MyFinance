﻿using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryLogSistema: IRepositoryBase<LogSistema>
    {
        public IEnumerable<LogSistema> GetAll(string userId);
        public new LogSistema GetById(string id);
    }
}