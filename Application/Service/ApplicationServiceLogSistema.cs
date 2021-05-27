using System.Collections.Generic;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Application.Service
{
    public class ApplicationServiceLogSistema : IApplicationServiceLogSistema
    {
        private readonly IServiceLogSistema _serviceLogSistema;

        public ApplicationServiceLogSistema(IServiceLogSistema serviceLogSistema)
        {
            _serviceLogSistema = serviceLogSistema;
        }

        public void Add(LogSistema logSistema)
        {
            _serviceLogSistema.Add(logSistema);
        }

        public IEnumerable<LogSistema> GetAll(string userId)
        {
            return _serviceLogSistema.GetAll(userId);
        }

        public LogSistema GetById(string id)
        {
            return _serviceLogSistema.GetById(id);
        }

        public void Dispose()
        {
            _serviceLogSistema.Dispose();
        }
    }
}