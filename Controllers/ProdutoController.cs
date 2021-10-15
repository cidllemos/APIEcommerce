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
    public class ProdutoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ProdutoResponse>> Get()
        {
            var produtos = ProdutoRepository.Buscar().Select(p => ProdutoMapper.Mapper(p));
            return produtos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoResponse> Get(int id)
        {
            var produto = ProdutoMapper.Mapper(ProdutoRepository.Buscar(id).FirstOrDefault());
            return produto;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ProdutoRequest request)
        {
            var produto = ProdutoMapper.Mapper(request);
            ProdutoRepository.Salvar(produto); 
            var retorno = new ReturnResponse()
            {
                Codigo = 200,
                Message = $"Registro {request.Descricao} cadastrado com sucesso"
            };

            return retorno;
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] ProdutoRequest request)
        {
            var produto = ProdutoMapper.Mapper(request);
            ProdutoRepository.Editar(produto); 
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
            ProdutoRepository.Delete(id);
            var retorno = new ReturnResponse()
            {
                Codigo = 200,
                Message = "Registro deletado com sucesso"
            };

            return retorno;
        }
    }
}
