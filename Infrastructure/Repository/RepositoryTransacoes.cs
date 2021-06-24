using System;
using System.Collections.Generic;
using System.Linq;
using CrossCutting;
using Domain.Core.Interfaces.Repositorys;
using Entities.Entities;
using Entities.Entities.Enums;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;

namespace Infrastructure.Repository
{
    public class RepositoryTransacoes : RepositoryBase<Transacoes>,IRepositoryTransacoes
    {
        private readonly MyFinancesContext _myFinancesContext;

        public RepositoryTransacoes(MyFinancesContext myFinancesContext) : base(myFinancesContext)
        {
            _myFinancesContext = myFinancesContext;
        }

        public IEnumerable<Transacoes> GetAll(string userId)
        {
            try
            {
                return _myFinancesContext.Transacao
                    .Include(t => t.Contas)
                    .Include(t => t.PlanoContas)
                    .Include(t => t.Usuario)
                    .Where(x => x.UserId == userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public Transacoes GetById(string id)
        {
            try
            {
                return _myFinancesContext.Transacao
                    .Include(t => t.Contas)
                    .Include(t => t.PlanoContas)
                    .Include(t => t.Usuario)
                    .FirstOrDefault(x => x.IdTransacoes == id);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<Transacoes> GetAllLimite10(string userId)
        {
            try
            {
                return _myFinancesContext.Transacao
                    .Include(t => t.Contas)
                    .Include(t => t.PlanoContas)
                    .Include(t => t.Usuario)
                    .Where(x => x.UserId == userId).Take(10);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<Transacoes> ExtratoTransacoes(Transacoes transacoes)
        {
            try
            {
                var result = _myFinancesContext.Transacao
                    .Include(t => t.Contas)
                    .Include(t => t.PlanoContas)
                    .Include(t => t.Usuario)
                    .Where(x => x.UserId == transacoes.UserId );

                //Datas de filtro
                if ((transacoes.DataInicio != DateTime.MinValue )&& (transacoes.DataFinal != DateTime.MinValue))
                {
                    result = result.Where(x => x.DataTransacao >= transacoes.DataInicio && x.DataTransacao <= transacoes.DataFinal);
                }
                else
                {
                    if (transacoes.DataInicio != DateTime.MinValue)
                    {
                        result = result.Where(x => x.DataTransacao >= transacoes.DataInicio && x.DataTransacao <= transacoes.DataInicio);
                    }
                }

                //Tipo de Despesas 
                if (transacoes.TipoDespesas != EnumTipoDespesas.Ambos)
                {
                    result = result.Where(x => x.TipoDespesas == transacoes.TipoDespesas);
                }


                //Conta 
                result = result.Where(x => x.ContaId == transacoes.ContaId);


                return result;
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }
    }
}