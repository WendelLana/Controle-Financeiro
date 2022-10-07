using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.models;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace ControleFinanceiro.controllers
{
    public class IncomeController : TransactionController
    {
        public IncomeController(Context context) : base(context)
        {
           
        }

        public List<Transaction> GetAll()
        {
            return _context.Transactions.Where(obj => obj.transactionType == "I").Include("Category").ToList();
        }

        public List<Category> GetAvailableCategories()
        {
            return _context.Categories.Where(obj => obj.transactionType == "I").ToList();
        }
    }
}       