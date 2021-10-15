using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Models
{
    [Table("PedidoItem")]
    public class PedidoItem : BaseModel
    {
        [ExplicitKey]
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
        public decimal ValorProduto { get; set; }
        public int Quantidade { get; set; }

    }
}
