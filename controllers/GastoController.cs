using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.models;
using Bogus;

namespace ControleFinanceiro.controllers
{
    public class GastoController
    {
        public List<MovimentacaoModel> readFakeValues()
        {
            var faker = new Faker<MovimentacaoModel>()
                .StrictMode(true)
                .RuleFor(g => g.gastoId, f => f.Random.Guid())
                .RuleFor(g => g.data, f => f.Date.Recent())
                .RuleFor(g => g.valor, f => f.Random.Decimal(0, 200000))
                .RuleFor(g => g.descricao, f => f.Random.Word())
                .RuleFor(g => g.categoriaId, f => f.Random.Guid());
            return faker.Generate(10);
        }
    }
}       