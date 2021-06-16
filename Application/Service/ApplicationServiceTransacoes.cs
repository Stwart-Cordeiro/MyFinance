using System;
using System.Collections.Generic;
using Application.Interfaces;
using Domain.Core.Interfaces.Services;
using Entities.Entities;
using Entities.Entities.Enums;

namespace Application.Service
{
    public class ApplicationServiceTransacoes : IApplicationServiceTransacoes
    {

        private readonly IServiceTransacoes _serviceTransacoes;
        private readonly IServiceConta _serviceConta;

        public ApplicationServiceTransacoes(IServiceTransacoes serviceTransacoes, IServiceConta serviceConta)
        {
            _serviceTransacoes = serviceTransacoes;
            _serviceConta = serviceConta;
        }

        public void Add(Transacoes transacoes)
        {
            var validaDescircao = transacoes.ValidarPropriedadeString(transacoes.Descricao, "Descrição");
            var validaValor = transacoes.ValidarPropriedadeDecimal(transacoes.Valor, "Valor");
            
            if (!validaDescircao || !validaValor) return;
            if (transacoes.Debito == true)
            {
                var conta = _serviceConta.GetById(transacoes.ContaId);

                if (transacoes.TipoDespesas == EnumTipoDespesas.Receita)
                {
                    conta.Valor += transacoes.Valor;
                }
                else
                {
                    conta.Valor -= transacoes.Valor;
                }

                _serviceConta.Update(conta);
            }
            transacoes.DataCadastro = DateTime.Now;
            _serviceTransacoes.Add(transacoes);

        }

        public void Update(Transacoes transacoes)
        {
            var validaDescircao = transacoes.ValidarPropriedadeString(transacoes.Descricao, "Descrição");
            var validaValor = transacoes.ValidarPropriedadeDecimal(transacoes.Valor, "Valor");

            if (!validaDescircao || !validaValor) return;
            transacoes.DataAlteracao = DateTime.Now;
            _serviceTransacoes.Update(transacoes);
        }

        public void Delete(Transacoes transacoes)
        {
            _serviceTransacoes.Delete(transacoes);
        }

        public Transacoes GetById(string id)
        {
            return _serviceTransacoes.GetById(id);
        }

        public IEnumerable<Transacoes> GetAll(string userId)
        {
            return _serviceTransacoes.GetAll(userId);
        }

        public void Dispose()
        {
            _serviceTransacoes.Dispose();
        }
    }
}