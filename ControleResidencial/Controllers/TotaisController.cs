using ControleResidencial.DTOs.Totais;
using Microsoft.AspNetCore.Mvc;
using ControleResidencial.Services.Interfaces;

namespace ControleResidencial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TotaisController : ControllerBase
    {

         // Aqui, vamos injetar a interface ao invés da PessoaService diretamente. Controller depende apenas do contrato, não da implementação concreta.
        // Isso permite que possamos trocar a implementação do serviço sem precisar alterar o controller, promovendo maior flexibilidade e testabilidade.
        private readonly ITotalService _totalService;

        public TotaisController (ITotalService totalService)
        {
            _totalService = totalService;
        }

        //Listar todas as pessoas cadastradas. Retorna uma lista de PessoaResponseDto.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TotaisResponseDto>> Listar()
        {
            var totais = await _totalService.ListarAsync();

            return Ok(totais);
        }
    }
}
