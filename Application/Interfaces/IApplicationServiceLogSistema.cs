using System.Collections.Generic;
using Entities.Entities;

namespace Application.Interfaces
{
    public interface IApplicationServiceLogSistema
    {
        void Add(LogSistema logSistema);
        LogSistema GetById(string id);
        IEnumerable<LogSistema> GetAll();
        void Dispose();
    }
}