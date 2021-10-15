using APIEcommerce.Models;
using APIEcommerce.Requests;
using APIEcommerce.Responses;

namespace APIEcommerce.Mapper
{
    public static class ClienteMapper
    {
        public static Cliente Mapper(ClienteRequest cliente)
        {
            return new Cliente()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Contato = cliente.Contato
            };
        }

        public static ClienteResponse Mapper(Cliente cliente)
        {
            return new ClienteResponse()
            {
                Id = cliente.Id.ToString(),
                Nome = cliente.Nome,
                Contato = cliente.Contato
            };
        }
    }
}
