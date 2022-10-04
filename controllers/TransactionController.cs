using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.models;

namespace ControleFinanceiro.controllers
{
    public class TransactionController
    {
        protected readonly Context _context;
        private readonly MainWindow _mainWindow;
        public TransactionController(Context context)
        {
            _context = context;
            _mainWindow = (MainWindow)System.Windows.Application.Current.MainWindow;
        }

        public List<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }
        public Transaction GetById(Guid id)
        {
            return _context.Transactions.FirstOrDefault(obj => obj.id == id);
        }

        public bool Add(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            _mainWindow.updateBalanceText();
            return true;
        }

        public bool Remove(Transaction transation)
        {
            _context.Transactions.Remove(transation);
            _context.SaveChanges();
            _mainWindow.updateBalanceText();
            return true;
        }

        public bool Update(Transaction transation)
        {
            _context.Transactions.Update(transation);
            _context.SaveChanges();
            _mainWindow.updateBalanceText();
            return true;
        }

        public decimal GetBalance()
        {
            decimal balance = 0;
            var items = _context.Transactions.ToList();

            items.ForEach(obj =>
            {
                balance += obj.transactionType == "I" ? Convert.ToDecimal(obj.value) : -Convert.ToDecimal(obj.value);
            });

            return balance;
        }
    }
}
