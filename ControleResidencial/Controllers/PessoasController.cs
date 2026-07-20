using ControleResidencial.DTOs.Pessoa;
using ControleResidencial.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleResidencial.Controllers
{

    // Controller responsável pelos endpoints relacionados ao cadastro de pessoas.
    // Atua como intermediário entre as requisições HTTP e a camada de serviços,
    // mantendo a regra de negócio centralizada no Service.
    [ApiController]
    [Route("api/[controller]")]
    public class PessoasController : ControllerBase
    {
        // Dependência injetada via interface para promover baixo acoplamento,
        // facilitar testes e permitir a substituição da implementação do serviço.
        private readonly IPessoaService _pessoaService;
    
        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        //GET: API/Pessoas/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PessoaResponseDto>> BuscarPorId(int id)
        {
            var pessoa = await _pessoaService.BuscarPorIdAsync(id);

            if (pessoa == null)
            {
                return NotFound(); // Retorna 404 se a pessoa não for encontrada.
            }
            return Ok(pessoa); // Retorna 200 com os dados da pessoa.
        }

        //POST: HttpPost para criar uma nova pessoa.
        [HttpPost]
        //ActionResult permite retornar códigos de status HTTP apropriados.
        //FromBody indica que os dados da pessoa serão enviados no corpo da requisição HTTP, apesar da ApiController fazer isso automaticamente.
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PessoaResponseDto>> Criar([FromBody]CreatePessoaDto dto)
        {
            var pessoa = await _pessoaService.CriarPessoaAsync(dto);
            return CreatedAtAction(nameof(BuscarPorId), new { id = pessoa.Id }, pessoa);
        }

        // Retorna todas as pessoas cadastradas.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<PessoaResponseDto>>> Listar()
        {
            var pessoas = await _pessoaService.ListarAsync();

            return Ok(pessoas); // Retorna 200 - Uma lista com todas as pessoas cadastradas.

        }

        // Remove uma pessoa e suas respectivas transações.
        // A exclusão em cascata é realizada pelo Entity Framework.
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExcluirAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest(); // Retorna 400 - Bad Request se o ID for inválido.
            }

            var deletadoSucesso = await _pessoaService.ExcluirAsync(id);

            if (!deletadoSucesso)
            {
                return NotFound(); // Retorna 404 - Not Found se a pessoa não for encontrada.
            }

            return NoContent();
        }

    }

}
