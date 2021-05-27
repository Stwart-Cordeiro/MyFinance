using System.Collections.Generic;
using Entities.Entities;

namespace Domain.Core.Interfaces.Services
{
    public interface IServiceConta : IServiceBase<Contas>
    {
        public IEnumerable<Contas> GetAll(string userId);
    }
}