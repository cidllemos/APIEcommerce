using APIEcommerce.Models;
using APIEcommerce.Requests;
using APIEcommerce.Responses;

namespace APIEcommerce.Mapper
{
    public static class EquipeMapper
    {
        public static Equipe Mapper(EquipeRequest equipe)
        {
            return new Equipe()
            {
                Id = equipe.Id,
                Nome = equipe.Nome,
                Descricao = equipe.Descricao,
                PlacaVeiculo = equipe.PlacaVeiculo
            };
        }

        public static EquipeResponse Mapper(Equipe equipe)
        {
            return new EquipeResponse()
            {
                Id = equipe.Id.ToString(),
                Nome = equipe.Nome,
                Descricao = equipe.Descricao,
                PlacaVeiculo = equipe.PlacaVeiculo
            };
        }
    }
}
