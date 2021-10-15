using APIEcommerce.Models;
using APIEcommerce.Requests;
using APIEcommerce.Responses;
using System.Linq;

namespace APIEcommerce.Mapper
{
    public static class PedidoMapper
    {
        public static Pedido Mapper(PedidoRequest pedido)
        {
            return new Pedido()
            {
                IdPedido = pedido.IdPedido,
                DataCriacao = pedido.DataCriacao,
                DataEntrega = pedido.DataEntrega,
                Endereco = pedido.Endereco,
                Cliente = ClienteMapper.Mapper(pedido.Cliente),
                Equipe = EquipeMapper.Mapper(pedido.Equipe),
                Itens = pedido.Itens.Select(x => PedidoItemMapper.Mapper(x)).ToList(),
            };
        }

        public static PedidoResponse Mapper(Pedido pedido)
        {
            return new PedidoResponse()
            {
                IdPedido = pedido.IdPedido.ToString(),
                DataCriacao = pedido.DataCriacao.ToString(),
                DataEntrega = pedido.DataEntrega.ToString(),
                Endereco = pedido.Endereco,
                Cliente = ClienteMapper.Mapper(pedido.Cliente),
                Equipe = EquipeMapper.Mapper(pedido.Equipe),
                Itens = pedido.Itens.Select(x => PedidoItemMapper.Mapper(x)).ToList()
            };
        }
    }
}
