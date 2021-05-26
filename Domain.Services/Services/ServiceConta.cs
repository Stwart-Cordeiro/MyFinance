﻿using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Domain.Services.Services
{
    public class ServiceConta : ServiceBase<Contas>,IServiceConta
    {
        private readonly IRepositoryConta _repositoryConta;

        public ServiceConta(IRepositoryConta repositoryConta) : base(repositoryConta)
        {
            _repositoryConta = repositoryConta;
        }
    }
}