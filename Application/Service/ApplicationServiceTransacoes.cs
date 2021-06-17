using System;
using System.Collections.Generic;
using Application.Interfaces;
using CrossCutting;
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
            Erro = new Erro();
        }

        public Erro Erro { get; set; }

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
            Erro = _serviceTransacoes.Erro;

        }

        public void Update(Transacoes transacoes)
        {
            var validaDescircao = transacoes.ValidarPropriedadeString(transacoes.Descricao, "Descrição");
            var validaValor = transacoes.ValidarPropriedadeDecimal(transacoes.Valor, "Valor");
            
            if (!validaDescircao || !validaValor) return;

            var transacaoAntiga = _serviceTransacoes.GetById(transacoes.IdTransacoes);
            var conta = _serviceConta.GetById(transacoes.ContaId);

            if (transacoes.ContaId == transacaoAntiga.ContaId)
            {
                if (transacoes.Debito == true)
                {

                    if (transacoes.TipoDespesas == EnumTipoDespesas.Receita)
                    {
                        conta.Valor -= transacaoAntiga.Valor;
                        conta.Valor += transacoes.Valor;
                    }
                    else
                    {
                        conta.Valor += transacaoAntiga.Valor;
                        conta.Valor -= transacoes.Valor;
                    }

                }
                else
                {
                    if (transacaoAntiga.Debito == true)
                    {
                        if (transacoes.TipoDespesas == EnumTipoDespesas.Receita)
                        {
                            conta.Valor -= transacaoAntiga.Valor;
                            conta.Valor += transacoes.Valor;
                        }
                        else
                        {
                            conta.Valor += transacaoAntiga.Valor;
                            conta.Valor -= transacoes.Valor;
                        }
                    }
                    else
                    {
                        if (transacoes.TipoDespesas == EnumTipoDespesas.Receita)
                        {
                            conta.Valor -= transacaoAntiga.Valor;
                            conta.Valor += transacoes.Valor;
                        }
                        else
                        {
                            conta.Valor += transacaoAntiga.Valor;
                            conta.Valor -= transacoes.Valor;
                        }
                    }

                }
            }
            else
            {
                if (transacoes.Debito == true)
                {

                    if (transacoes.TipoDespesas == EnumTipoDespesas.Receita)
                    {
                        conta.Valor -= transacaoAntiga.Valor;
                        conta.Valor += transacoes.Valor;
                    }
                    else
                    {
                        conta.Valor += transacaoAntiga.Valor;
                        conta.Valor -= transacoes.Valor;
                    }

                }
                else
                {
                    if (transacaoAntiga.Debito == true)
                    {
                        if (transacoes.TipoDespesas == EnumTipoDespesas.Receita)
                        {
                            conta.Valor -= transacaoAntiga.Valor;
                            conta.Valor += transacoes.Valor;
                        }
                        else
                        {
                            conta.Valor += transacaoAntiga.Valor;
                            conta.Valor -= transacoes.Valor;
                        }
                    }
                    else
                    {
                        if (transacoes.TipoDespesas == EnumTipoDespesas.Receita)
                        {
                            conta.Valor -= transacaoAntiga.Valor;
                            conta.Valor += transacoes.Valor;
                        }
                        else
                        {
                            conta.Valor += transacaoAntiga.Valor;
                            conta.Valor -= transacoes.Valor;
                        }
                    }

                }
            }

            _serviceConta.Update(conta);

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

        public void Dispose()
        {
            _serviceTransacoes.Dispose();
        }
    }
}