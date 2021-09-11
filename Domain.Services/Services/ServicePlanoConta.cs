using System;
using System.Collections.Generic;
using CrossCutting;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Domain.Services.Services
{
    public class ServicePlanoConta : ServiceBase<PlanoContas>,IServicePlanoConta
    {

        private readonly IRepositoryPlanoConta _repositoryPlanoConta;


        public ServicePlanoConta(IRepositoryPlanoConta repositoryPlanoConta) : base(repositoryPlanoConta)
        {
            _repositoryPlanoConta = repositoryPlanoConta;
        }

        public IEnumerable<PlanoContas> GetAll(string userId)
        {
            try
            {
                return _repositoryPlanoConta.GetAll(userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public PlanoContas GetById(string id)
        {
            try
            {
                return _repositoryPlanoConta.GetById(id);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<PlanoContas> GetAllAtivadas(string userId)
        {
            try
            {
                return _repositoryPlanoConta.GetAllAtivadas(userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<PlanoContas> GetSearch(string search, string userId)
        {
            try
            {
                return _repositoryPlanoConta.GetSearch(search,userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }
    }
}