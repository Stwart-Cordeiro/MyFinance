using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Application.Service
{
    public class ApplicationServicePlanoConta : IApplicationServicePlanoConta
    {
        private readonly IServicePlanoConta _servicePlanoConta;

        public ApplicationServicePlanoConta(IServicePlanoConta servicePlanoConta)
        {
            _servicePlanoConta = servicePlanoConta;
        }
        
        public void Add(PlanoContas planoContas)
        {
            var validaNome = planoContas.ValidarPropriedadeString(planoContas.Nome, "Nome");

            if (!validaNome) return;
            planoContas.DataCadastro = DateTime.Now;
            _servicePlanoConta.Add(planoContas);
        }

        public void Update(PlanoContas planoContas)
        {
            var validaNome = planoContas.ValidarPropriedadeString(planoContas.Nome, "Nome");

            if (!validaNome) return;
            planoContas.DataAlteracao = DateTime.Now;
            _servicePlanoConta.Update(planoContas);
        }

        public void Delete(PlanoContas planoContas)
        {
            _servicePlanoConta.Delete(planoContas);
        }

        public PlanoContas GetById(string id)
        {
            return _servicePlanoConta.GetById(id);
        }

        public IEnumerable<PlanoContas> GetAll(string userId)
        {
            return _servicePlanoConta.GetAll(userId);
        }

        public void Dispose()
        {
            _servicePlanoConta.Dispose();
        }
    }
}