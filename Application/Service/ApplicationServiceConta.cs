using System;
using System.Collections.Generic;
using Application.Interfaces;
using CrossCutting;
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
            Erro = new Erro();
        }
        public Erro Erro { get; set; }
        public void Add(Contas conta)
        {
            var validaNome = conta.ValidarPropriedadeString(conta.Nome, "Nome");

            if (!validaNome) return;
            conta.DataCadastro = DateTime.Now;
            _serviceConta.Add(conta);
            Erro = _serviceConta.Erro;
        }

        public void Update(Contas conta)
        {
            var validaNome = conta.ValidarPropriedadeString(conta.Nome, "Nome");

            if (!validaNome) return;
            conta.DataAlteracao = DateTime.Now;
            _serviceConta.Update(conta);
            Erro = _serviceConta.Erro;
        }

        public void Delete(Contas conta)
        {
            _serviceConta.Delete(conta);
            Erro = _serviceConta.Erro;
        }

        public Contas GetById(string id)
        {
            var lista = _serviceConta.GetById(id);
            Erro = _serviceConta.Erro;
            return lista;
        }

        public IEnumerable<Contas> GetAll(string userId)
        {
            var lista= _serviceConta.GetAll(userId);
            Erro = _serviceConta.Erro;
            return lista;
        }

        public IEnumerable<Contas> GetAllAtivadas(string userId)
        {
            var lista = _serviceConta.GetAllAtivadas(userId);
            Erro = _serviceConta.Erro;
            return lista;
        }

        public void Dispose()
        {
            _serviceConta.Dispose();
        }
    }
}