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
                IdPedido = pedidoItem.idPedido,
                Produto = ProdutoMapper.Mapper(pedidoItem.Produto),
                Quantidade = pedidoItem.Quantidade,
                ValorProduto = pedidoItem.ValorProduto
            };
        }

        public static PedidoItemResponse Mapper(PedidoItem pedidoItem)
        {
            return new PedidoItemResponse()
            {
                idPedidoItem = pedidoItem.IdPedidoItem.ToString(),
                idPedido = pedidoItem.IdPedido.ToString(),
                Produto = ProdutoMapper.Mapper(pedidoItem.Produto),
                Quantidade = pedidoItem.Quantidade.ToString(),
                ValorProduto = pedidoItem.ValorProduto.ToString()

            };
        }
    }
}
