using APIEcommerce.Models;
using APIEcommerce.Requests;
using APIEcommerce.Responses;

namespace APIEcommerce.Mapper
{
    public static class ProdutoMapper
    {
        public static Produto Mapper(ProdutoRequest produtoRequest)
        {
            return new Produto()
            {
                IdProduto = produtoRequest.IdProduto,
                Nome = produtoRequest.Nome,
                ValorUnitario = produtoRequest.ValorUnitario,
                Descricao = produtoRequest.Descricao
            };
        }

        public static ProdutoResponse Mapper(Produto produto)
        {
            return new ProdutoResponse()
            {
                IdProduto = produto.IdProduto.ToString(),
                Nome = produto.Nome,
                ValorUnitario = produto.ValorUnitario.ToString(),
                Descricao = produto.Descricao
            };
        }
    }
}