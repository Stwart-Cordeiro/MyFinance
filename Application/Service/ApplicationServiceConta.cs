using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Application.Service
{
    public class ApplicationServiceConta : IApplicationServiceConta
    {
        private readonly IServiceConta _serviceConta;

        public ApplicationServiceConta(IServiceConta serviceConta)
        {
            _serviceConta = serviceConta;
        }


        public void Add(Contas conta)
        {
            var validaNome = conta.ValidarPropriedadeString(conta.Nome, "Nome");

            if (!validaNome) return;
            conta.DataCadastro = DateTime.Now;
            _serviceConta.Add(conta);
        }

        public void Update(Contas conta)
        {
            var validaNome = conta.ValidarPropriedadeString(conta.Nome, "Nome");

            if (!validaNome) return;
            conta.DataAlteracao = DateTime.Now;
            _serviceConta.Update(conta);
        }

        public void Delete(Contas conta)
        {
            _serviceConta.Delete(conta);
        }

        public Contas GetById(string id)
        {
            return _serviceConta.GetById(id);
        }

        public IEnumerable<Contas> GetAll()
        {
            return _serviceConta.GetAll();
        }

        public void Dispose()
        {
            _serviceConta.Dispose();
        }
    }
}