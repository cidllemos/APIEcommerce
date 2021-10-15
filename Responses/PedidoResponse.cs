using APIEcommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Responses
{
    public class PedidoResponse
    {
        public string Id { get; set; }
        public string DataCriacao { get; set; }
        public string DataEntrega { get; set; }
        public string Endereco { get; set; }
        public ClienteResponse Cliente { get; set; }
        public EquipeResponse Equipe { get; set; }
        public List<PedidoItemResponse> Itens { get; set; }
    }
}
