using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.models
{
    public class Category
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;

        public string color { get; set; } = "#FF000000";

        public string icon { get; set; } = string.Empty;
        public string pack { get; set; } = string.Empty;
        public string transactionType { get; set; } = string.Empty;

        public Category() { }
    }
}
