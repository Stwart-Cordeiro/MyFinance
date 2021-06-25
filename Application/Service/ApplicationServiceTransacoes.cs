using System;
using System.Collections.Generic;
using Application.Interfaces;
using CrossCutting;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Application.Service
{
    public class ApplicationServiceTransacoes : IApplicationServiceTransacoes
    {

        private readonly IServiceTransacoes _serviceTransacoes;

        public ApplicationServiceTransacoes(IServiceTransacoes serviceTransacoes)
        {
            _serviceTransacoes = serviceTransacoes;
            Erro = new Erro();
        }

        public Erro Erro { get; set; }

        public void Add(Transacoes transacoes)
        {
            var validaDescircao = transacoes.ValidarPropriedadeString(transacoes.Descricao, "Descrição");
            var validaValor = transacoes.ValidarPropriedadeDecimal(transacoes.Valor, "Valor");
            
            if (!validaDescircao || !validaValor) return;
           
            transacoes.DataCadastro = DateTime.Now;
            _serviceTransacoes.Add(transacoes);
            Erro = _serviceTransacoes.Erro;

        }

        public void Update(Transacoes transacoes)
        {
            var validaDescircao = transacoes.ValidarPropriedadeString(transacoes.Descricao, "Descrição");
            var validaValor = transacoes.ValidarPropriedadeDecimal(transacoes.Valor, "Valor");
            
            if (!validaDescircao || !validaValor) return;

            transacoes.DataAlteracao = DateTime.Now;

            _serviceTransacoes.Update(transacoes);

            Erro = _serviceTransacoes.Erro;
        }

        public void Delete(Transacoes transacoes)
        {
            _serviceTransacoes.Delete(transacoes);
            Erro = _serviceTransacoes.Erro;
        }

        public Transacoes GetById(string id)
        {
            var lista= _serviceTransacoes.GetById(id);
            Erro = _serviceTransacoes.Erro;
            return lista;
        }

        public IEnumerable<Transacoes> GetAll(string userId)
        {
            var lista= _serviceTransacoes.GetAll(userId);
            Erro = _serviceTransacoes.Erro;
            return lista;
        }

        public IEnumerable<Transacoes> GetAllLimite10(string userId)
        {
            var lista = _serviceTransacoes.GetAllLimite10(userId);
            Erro = _serviceTransacoes.Erro;
            return lista;
        }

        public IEnumerable<Transacoes> ExtratoTransacoes(Transacoes transacoes)
        {
            var lista = _serviceTransacoes.ExtratoTransacoes(transacoes);
            Erro = _serviceTransacoes.Erro;
            return lista;
        }

        public IEnumerable<Dashboard> ExtratoDespesas(string userId)
        {
            var lista = _serviceTransacoes.ExtratoDespesas(userId);
            Erro = _serviceTransacoes.Erro;
            return lista;
        }

        public IEnumerable<Dashboard> ExtratoReceitas(string userId)
        {
            var lista = _serviceTransacoes.ExtratoReceitas(userId);
            Erro = _serviceTransacoes.Erro;
            return lista;
        }

        public void Dispose()
        {
            _serviceTransacoes.Dispose();
        }

        
    }
}