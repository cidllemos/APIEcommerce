using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Responses
{
    public class PedidoItemResponse
    {
        public PedidoResponse Pedido { get; set; }
        public ProdutoResponse Produto { get; set; }
        public string ValorProduto { get; set; }
        public string Quantidade { get; set; }
    }
}
