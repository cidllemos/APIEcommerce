using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Responses
{
    public class ProdutoResponse
    {
        public string IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ValorUnitario { get; set; }
    }
}
