using System;
using System.Collections.Generic;
using CrossCutting;
using Domain.Core.Interfaces.Repositorys;
using Domain.Core.Interfaces.Services;

namespace Domain.Services.Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>, IDisposable where TEntity: class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        protected ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
            Erro = new Erro();
        }

        public Erro Erro { get; set; }

        public void Add(TEntity entity)
        {
            try
            {
                _repository.Add(entity);

                if (_repository.Erro.Numero != Erro.Tipo.SemErro)
                {
                    Erro = new Erro(Erro.Tipo.Indefinido, _repository.Erro.Mensagem);
                }
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _repository.Update(entity);

                if (_repository.Erro.Numero != Erro.Tipo.SemErro)
                {
                    Erro = new Erro(Erro.Tipo.Indefinido, _repository.Erro.Mensagem);
                }

            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _repository.Delete(entity);

                if (_repository.Erro.Numero != Erro.Tipo.SemErro)
                {
                    Erro = new Erro(Erro.Tipo.Indefinido, _repository.Erro.Mensagem);
                }

            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }
        }

        public TEntity GetById(string id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception erro)
            {
                Erro = new Erro(Erro.Tipo.Indefinido, erro.Message);
            }

            return null;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}