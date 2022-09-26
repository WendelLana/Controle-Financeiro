using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.models
{
    public class MovimentacaoModel
    {
        public Guid gastoId { get; set; } = Guid.Empty;
        public DateTime data { get; set; } = DateTime.Now;
        public decimal valor { get; set; } = 0;
        public string descricao { get; set; } = string.Empty;
        public Guid categoriaId { get; set; } = Guid.Empty;

        public MovimentacaoModel() { }
        // Construtor para copiar um objeto
        public MovimentacaoModel(MovimentacaoModel model)
        {
            gastoId = model.gastoId;
            data = model.data;
            valor = model.valor;
            descricao = model.descricao;
            categoriaId = model.categoriaId;
        }
    }
}
