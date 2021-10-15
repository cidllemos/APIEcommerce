using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Responses
{
    public class PedidoItemResponse
    {
        public string IdPedidoItem { get; set; }
        public string IidPedido { get; set; }
        public ProdutoResponse Produto { get; set; }
        public string Valor { get; set; }
        public string Quantidade { get; set; }
    }
}
