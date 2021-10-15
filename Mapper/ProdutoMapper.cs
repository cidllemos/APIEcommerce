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
                Id = produtoRequest.Id,
                Nome = produtoRequest.Nome,
                Valor = produtoRequest.Valor,
                Descricao = produtoRequest.Descricao
            };
        }

        public static ProdutoResponse Mapper(Produto produto)
        {
            return new ProdutoResponse()
            {
                Id = produto.Id.ToString(),
                Nome = produto.Nome,
                Valor = produto.Valor.ToString(),
                Descricao = produto.Descricao
            };
        }
    }
}