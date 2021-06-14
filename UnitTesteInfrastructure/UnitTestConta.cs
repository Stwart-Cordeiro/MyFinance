using System;
using System.Linq;
using Application.Service;
using Domain.Services.Services;
using Entities.Entities;
using Entities.Entities.Enums;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesteInfrastructure
{
    [TestClass]
    public class UnitTestConta
    {

        private readonly ApplicationServiceConta _applicationServiceConta;

        public UnitTestConta()
        {
            _applicationServiceConta = new ApplicationServiceConta(
                new ServiceConta(
                    new RepositoryConta(new MyFinancesContext(new DbContextOptions<MyFinancesContext>()))));
        }

        [TestMethod]
        public void AddContaTask()
        {
            try
            {
                var contaSucesso = new Contas
                {
                    IdConta = Guid.NewGuid().ToString(),
                    Nome = "Conta Teste",
                    Valor = 100,
                    Status = EnumStatus.Ativado,
                    TipoDespesas = EnumTipoDespesas.Receita,
                    UserId = Guid.NewGuid().ToString(),
                    DataCadastro = DateTime.Now.Date
                };

                _applicationServiceConta.Add(contaSucesso);

                Assert.IsFalse(contaSucesso.Notificacoes.Any());
            }
            catch (Exception erroException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void AddContaNoNomeTask()
        {
            try
            {
                var contaSucesso = new Contas
                {
                    IdConta = Guid.NewGuid().ToString(),
                    Status = EnumStatus.Ativado,
                    TipoDespesas = EnumTipoDespesas.Receita,
                    UserId = Guid.NewGuid().ToString(),
                    DataCadastro = DateTime.Now.Date
                };

                Assert.IsFalse(contaSucesso.Notificacoes.Any());

                _applicationServiceConta.Add(contaSucesso);

            }
            catch (Exception erroException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UpdateContaTask()
        {
            try
            {
                var contaSucesso = new Contas
                {
                    IdConta = Guid.NewGuid().ToString(),
                    Nome = "Conta Teste update",
                    Status = EnumStatus.Desativado,
                    TipoDespesas = EnumTipoDespesas.Despesas,
                    UserId = Guid.NewGuid().ToString(),
                };

                _applicationServiceConta.Update(contaSucesso);

                Assert.IsFalse(contaSucesso.Notificacoes.Any());
            }
            catch (Exception erroException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void DeleteContaTask()
        {
            try
            {
                var contaSucesso = new Contas
                {
                    IdConta = Guid.NewGuid().ToString(),
                    Nome = "Conta Teste",
                    Status = EnumStatus.Ativado,
                    TipoDespesas = EnumTipoDespesas.Receita,
                    UserId = Guid.NewGuid().ToString(),
                    DataCadastro = DateTime.Now.Date
                };

                _applicationServiceConta.Delete(contaSucesso);

                Assert.IsFalse(contaSucesso.Notificacoes.Any());
            }
            catch (Exception erroException)
            {
                Assert.Fail();
            }
        }

    }
}