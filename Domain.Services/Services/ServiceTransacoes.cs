using System;
using System.Collections.Generic;
using CrossCutting;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;
using Entities.Entities;

namespace Domain.Services.Services
{
    public class ServiceTransacoes : ServiceBase<Transacoes>,IServiceTransacoes
    {
        private readonly IRepositoryTransacoes _repositoryTransacoes;

        public ServiceTransacoes(IRepositoryTransacoes repositoryTransacoes) : base(repositoryTransacoes)
        {
            _repositoryTransacoes = repositoryTransacoes;
        }

        public IEnumerable<Transacoes> GetAll(string userId)
        {
            try
            {
                return _repositoryTransacoes.GetAll(userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public new Transacoes GetById(string id)
        {
            try
            {
                return _repositoryTransacoes.GetById(id);
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
                return _repositoryTransacoes.GetAllLimite10(userId);
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
                return _repositoryTransacoes.ExtratoTransacoes(transacoes);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<Dashboard> ExtratoDespesas(string userId)
        {
            try
            {
                return _repositoryTransacoes.ExtratoDespesas(userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<Dashboard> ExtratoReceitas(string userId)
        {
            try
            {
                return _repositoryTransacoes.ExtratoReceitas(userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<Transacoes> GetSearch(string search, string userId)
        {
            try
            {
                return _repositoryTransacoes.GetSearch(search,userId);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }
    }
}