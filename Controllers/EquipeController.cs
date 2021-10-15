using APIEcommerce.Mapper;
using APIEcommerce.Repositories;
using APIEcommerce.Requests;
using APIEcommerce.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EquipeResponse>> Get()
        {
            var equipes = EquipeRepository.Buscar().Select(p => EquipeMapper.Mapper(p));
            return equipes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<EquipeResponse> Get(int id)
        {
            var equipe = EquipeMapper.Mapper(EquipeRepository.Buscar(id).FirstOrDefault());
            return equipe;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] EquipeRequest request)
        {
            var equipe = EquipeMapper.Mapper(request);
            EquipeRepository.Salvar(equipe); 
            var retorno = new ReturnResponse()
            {
                Codigo = 200,
                Message = "Registro salvo com sucesso"
            };

            return retorno;
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] EquipeRequest request)
        {
            var equipe = EquipeMapper.Mapper(request);
            EquipeRepository.Editar(equipe); 
            var retorno = new ReturnResponse()
            {
                Codigo = 200,
                Message = "Registro atualizado com sucesso"
            };

            return retorno;
        }

        [HttpDelete("{id}")]
        public ActionResult<ReturnResponse> Delete(int id)
        {
            EquipeRepository.Delete(id);
            var retorno = new ReturnResponse()
            {
                Codigo = 200,
                Message = "Registro deletado com sucesso"
            };

            return retorno;
        }
    }
}
