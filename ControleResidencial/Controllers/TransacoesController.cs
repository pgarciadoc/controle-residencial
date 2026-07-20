using ControleResidencial.DTOs.Transacao;
using ControleResidencial.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleResidencial.Controllers
{
    // Controller responsável pelos endpoints relacionados as Transações.
    // Atua como intermediário entre as requisições HTTP e a camada de serviços,
    // mantendo a regra de negócio centralizada no Service.

    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {

        // Dependência injetada via interface para promover baixo acoplamento,
        // facilitar testes e permitir a substituição da implementação do serviço.
        private readonly ITransacaoService _transacaoService;

        public TransacoesController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

         //POST: HttpPost para criar uma nova pessoa.
        [HttpPost]
        //ActionResult permite retornar códigos de status HTTP apropriados.
        //FromBody indica que os dados da pessoa serão enviados no corpo da requisição HTTP, apesar da ApiController fazer isso automaticamente.
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TransacaoResponseDto>> Criar([FromBody]CreateTransacaoDto dto)
        {
            //try catch para tratar exceções
            try
            {
                var transacao = await _transacaoService.CriarAsync(dto);

                return StatusCode(StatusCodes.Status201Created, transacao);


            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }


        }

        // GET: api/Transacoes
        // Lista todas as transações cadastradas.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TransacaoResponseDto>>> Listar()
        {
            var transacoes = await _transacaoService.ListarAsync();

            return Ok(transacoes);
        }
    }   
}
