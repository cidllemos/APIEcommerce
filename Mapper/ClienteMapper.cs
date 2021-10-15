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
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                Contato = cliente.Contato
            };
        }

        public static ClienteResponse Mapper(Cliente cliente)
        {
            return new ClienteResponse()
            {
                IdCliente = cliente.IdCliente.ToString(),
                Nome = cliente.Nome,
                Contato = cliente.Contato
            };
        }
    }
}
