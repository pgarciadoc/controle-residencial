using ControleResidencial.DTOs.Totais;
using Microsoft.AspNetCore.Mvc;
using ControleResidencial.Services.Interfaces;

namespace ControleResidencial.Controllers
{
    // Controller responsável pelos endpoints relacionados aos Totais.
    // Atua como intermediário entre as requisições HTTP e a camada de serviços,
    // mantendo a regra de negócio centralizada no Service.

    [ApiController]
    [Route("api/[controller]")]
    public class TotaisController : ControllerBase
    {
        // Dependência injetada via interface para promover baixo acoplamento,
        // facilitar testes e permitir a substituição da implementação do serviço.
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
