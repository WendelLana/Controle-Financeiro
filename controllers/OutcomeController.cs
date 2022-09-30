using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.models;
using Bogus;

namespace ControleFinanceiro.controllers
{
    public class OutcomeController : TransactionController
    {

        public OutcomeController(Context context) : base(context) { }

        public List<Transaction> GetAll()
        {
            return _context.Transactions.Where(obj => obj.transactionType == "O").ToList();
        }

        //public List<Transaction> readFakeValues()
        //{
        //    var faker = new Faker<Transaction>()
        //        .StrictMode(true)
        //        .RuleFor(g => g.id, f => f.Random.Guid())
        //        .RuleFor(g => g.date, f => f.Date.Recent())
        //        .RuleFor(g => g.value, f => f.Random.Decimal(0, 200000))
        //        .RuleFor(g => g.description, f => f.Random.Word())
        //        .RuleFor(g => g.categoryId, f => f.Random.Guid());
        //    return faker.Generate(10);
        //}
    }
}       