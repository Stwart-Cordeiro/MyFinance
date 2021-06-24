using System;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;
using System.Collections.Generic;
using CrossCutting;

namespace Domain.Services.Services
{
    public class ServiceLogSistema : ServiceBase<LogSistema>, IServiceLogSistema
    {
        private readonly IRepositoryLogSistema _repositoryLogSistema;

        public ServiceLogSistema(IRepositoryLogSistema repositoryLogSistema) : base(repositoryLogSistema)
        {
            _repositoryLogSistema = repositoryLogSistema;
        }

        public IEnumerable<LogSistema> GetAll(string userId)
        {
            try
            {
                return _repositoryLogSistema.GetAll(userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public LogSistema GetById(string id)
        {
            try
            {
                return _repositoryLogSistema.GetById(id);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }
    }
}