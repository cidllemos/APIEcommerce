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
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ClienteResponse>> Get()
        {
            var clientes = ClienteRepository.Buscar().Select(p => ClienteMapper.Mapper(p));
            return clientes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ClienteResponse> Get(int id)
        {
            var cliente = ClienteMapper.Mapper(ClienteRepository.Buscar(id).FirstOrDefault());
            return cliente;
        }

        [HttpPost]
        public ActionResult<ReturnResponse> Post([FromBody] ClienteRequest request)
        {
            var cliente = ClienteMapper.Mapper(request);
            ClienteRepository.Salvar(cliente);
            var retorno = new ReturnResponse()
            {
                Codigo = 200,
                Message = "Registro salvo com sucesso"
            };

            return retorno;
        }

        [HttpPut]
        public ActionResult<ReturnResponse> Put([FromBody] ClienteRequest request)
        {
            var cliente = ClienteMapper.Mapper(request);
            ClienteRepository.Editar(cliente);
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
            ClienteRepository.Delete(id);
            var retorno = new ReturnResponse()
            {
                Codigo = 200,
                Message = "Registro deletado com sucesso"
            };

            return retorno;
        }
    }
}
