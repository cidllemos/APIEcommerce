using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Requests
{
    public class PedidoItemRequest
    {
        public int IdPedidoItem { get; set; } 
        public int IdPedido { get; set; }
        public ProdutoRequest Produto { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
