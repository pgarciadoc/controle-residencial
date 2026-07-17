using ControleResidencial.DTOs.Transacao;
using ControleResidencial.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleResidencial.Controllers
{
        //Indicando que trata-se de um controller de API e definindo a rota base para as ações do controller.
    [ApiController]
    [Route("api/[controller]")]
    public class TransacoesController : ControllerBase
    {

        // Aqui, vamos injetar a interface ao invés da PessoaService diretamente. Controller depende apenas do contrato, não da implementação concreta.
        // Isso permite que possamos trocar a implementação do serviço sem precisar alterar o controller, promovendo maior flexibilidade e testabilidade.
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
