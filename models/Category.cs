using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.models
{
    public class Category
    {
        public Guid categoryId { get; set; }
        public string name { get; set; } = string.Empty;

        public string color { get; set; } = string.Empty;

        public string icon { get; set; } = string.Empty;
    }
}
