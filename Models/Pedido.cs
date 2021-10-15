using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEcommerce.Models
{
    [Table("Pedido")]
    public class Pedido : BaseModel
    {
        [ExplicitKey]
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Endereco { get; set; }
        public Cliente Cliente { get; set; }
        public Equipe Equipe { get; set; }
        public List<PedidoItem> Itens { get; set; }
    }
}
