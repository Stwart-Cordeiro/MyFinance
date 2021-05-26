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
            _applicationServiceConta = new ApplicationServiceConta(new ServiceConta(new RepositoryConta(new MyFinancesContext(new DbContextOptions<MyFinancesContext>()))));
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
    }
}