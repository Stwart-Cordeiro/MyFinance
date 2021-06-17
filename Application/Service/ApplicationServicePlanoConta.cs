using System;
using System.Collections.Generic;
using Application.Interfaces;
using CrossCutting;
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
            Erro = new Erro();
        }

        public Erro Erro { get; set; }

        public void Add(PlanoContas planoContas)
        {
            var validaNome = planoContas.ValidarPropriedadeString(planoContas.Nome, "Nome");

            if (!validaNome) return;
            planoContas.DataCadastro = DateTime.Now;
            _servicePlanoConta.Add(planoContas);
            Erro = _servicePlanoConta.Erro;
        }

        public void Update(PlanoContas planoContas)
        {
            var validaNome = planoContas.ValidarPropriedadeString(planoContas.Nome, "Nome");

            if (!validaNome) return;
            planoContas.DataAlteracao = DateTime.Now;
            _servicePlanoConta.Update(planoContas);
            Erro = _servicePlanoConta.Erro;
        }

        public void Delete(PlanoContas planoContas)
        {
            _servicePlanoConta.Delete(planoContas);
            Erro = _servicePlanoConta.Erro;
        }

        public PlanoContas GetById(string id)
        {
            var lista= _servicePlanoConta.GetById(id);
            Erro = _servicePlanoConta.Erro;
            return lista;
        }

        public IEnumerable<PlanoContas> GetAll(string userId)
        {
            var lista = _servicePlanoConta.GetAll(userId);
            Erro = _servicePlanoConta.Erro;
            return lista;
        }

        public IEnumerable<PlanoContas> GetAllAtivadas(string userId)
        {
            var lista = _servicePlanoConta.GetAllAtivadas(userId);
            Erro = _servicePlanoConta.Erro;
            return lista;
        }

        public void Dispose()
        {
            _servicePlanoConta.Dispose();
        }
    }
}