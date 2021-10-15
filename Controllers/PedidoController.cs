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
    public class PedidoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PedidoResponse>> Get()
        {
            var clientes = PedidoRepository.Buscar().Select(p => PedidoMapper.Mapper(p));
            return clientes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<PedidoResponse> Get(int id)
        {
            var pedido = PedidoMapper.Mapper(PedidoRepository.Buscar(id).FirstOrDefault());
            return pedido;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] PedidoRequest request)
        {
            var pedido = PedidoMapper.Mapper(request);
            PedidoRepository.Salvar(pedido);
            var retorno = new ReturnResponse()
            {
                Codigo = 200,
                Message = "Registro salvo com sucesso"
            };

            return retorno;
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] PedidoRequest request)
        {
            var pedido = PedidoMapper.Mapper(request);
            PedidoRepository.Editar(pedido); 
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
            PedidoRepository.Delete(id);
            var retorno = new ReturnResponse()
            {
                Codigo = 200,
                Message = "Registro deletado com sucesso"
            };

            return retorno;
        }
    }
}
