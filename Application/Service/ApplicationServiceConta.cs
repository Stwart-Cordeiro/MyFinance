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
            throw new System.NotImplementedException();
        }

        public void Delete(Contas conta)
        {
            throw new System.NotImplementedException();
        }

        public Contas GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Contas> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}