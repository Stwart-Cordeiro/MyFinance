﻿using System.Collections.Generic;
using CrossCutting;
using Entities.Entities;

namespace Application.Interfaces
{
    public interface IApplicationServiceTransacoes
    {
        Erro Erro { get; set; }
        void Add(Transacoes transacoes);
        void Update(Transacoes transacoes);
        void Delete(Transacoes transacoes);
        Transacoes GetById(string id);
        IEnumerable<Transacoes> GetAll(string userId);
        IEnumerable<Transacoes> GetAllLimite10(string userId);
        IEnumerable<Transacoes> ExtratoTransacoes(Transacoes transacoes);
        IEnumerable<Dashboard> ExtratoDespesas(string userId);
        IEnumerable<Dashboard> ExtratoReceitas(string userId);
        IEnumerable<Transacoes> GetSearch(string search, string userId);
        void Dispose();
    }
}