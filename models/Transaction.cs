using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.models
{
    public class Transaction
    {
        public Guid id { get; set; } = Guid.Empty;
        public DateTime date { get; set; } = DateTime.Now;
        public decimal value { get; set; } = 0;
        public string description { get; set; } = string.Empty;
        public Guid categoryId { get; set; } = Guid.Empty;
        public Category Category { get; set; }
        public string transactionType { get; set; } = string.Empty;

        public Transaction() { }
    }
}
