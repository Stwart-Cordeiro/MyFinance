using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Services
{
    public interface IServiceLogSistema: IServiceBase<LogSistema>
    {
        public IEnumerable<LogSistema> GetAll(string userId);
        public LogSistema GetById(string id);
    }
}