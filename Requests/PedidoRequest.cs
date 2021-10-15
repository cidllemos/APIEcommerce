using APIEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Requests
{
    public class PedidoRequest
    {
        public int IdPedido { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Endereco { get; set; }
        public ClienteRequest Cliente { get; set; }
        public EquipeRequest Equipe { get; set; }
        public List<PedidoItemRequest> Itens { get; set; }
    }
}
