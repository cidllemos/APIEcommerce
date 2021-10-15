using APIEcommerce.Models;
using APIEcommerce.Requests;
using APIEcommerce.Responses;

namespace APIEcommerce.Mapper
{
    public static class PedidoItemMapper
    {
        public static PedidoItem Mapper(PedidoItemRequest pedidoItem)
        {
            return new PedidoItem()
            {
                IdPedidoItem = pedidoItem.IdPedidoItem,
                IdPedido = pedidoItem.IdPedido,
                Produto = ProdutoMapper.Mapper(pedidoItem.Produto),
                Quantidade = pedidoItem.Quantidade,
                Valor = pedidoItem.Valor
            };
        }

        public static PedidoItemResponse Mapper(PedidoItem pedidoItem)
        {
            return new PedidoItemResponse()
            {
                IdPedidoItem = pedidoItem.IdPedidoItem.ToString(),
                IidPedido = pedidoItem.IdPedido.ToString(),
                Produto = ProdutoMapper.Mapper(pedidoItem.Produto),
                Quantidade = pedidoItem.Quantidade.ToString(),
                Valor = pedidoItem.Valor.ToString()

            };
        }
    }
}
