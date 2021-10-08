using System;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;
using System.Collections.Generic;
using CrossCutting;

namespace Domain.Services.Services
{
    public class ServiceConta : ServiceBase<Contas>,IServiceConta
    {
        private readonly IRepositoryConta _repositoryConta;

        public ServiceConta(IRepositoryConta repositoryConta) : base(repositoryConta)
        {
            _repositoryConta = repositoryConta;
        }

        public IEnumerable<Contas> GetAll(string userId)
        {
            try
            {
                return _repositoryConta.GetAll(userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public new Contas GetById(string id)
        {
            try
            {
                return _repositoryConta.GetById(id);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<Contas> GetAllAtivadas(string userId)
        {
            try
            {
                return _repositoryConta.GetAllAtivadas(userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<Contas> GetSearch(string search, string userId)
        {
            try
            {
                return _repositoryConta.GetSearch(search, userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }
    }
}