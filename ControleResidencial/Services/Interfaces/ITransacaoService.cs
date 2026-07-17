
using ControleResidencial.DTOs.Transacao;

namespace ControleResidencial.Services.Interfaces
{
    public interface ITransacaoService
    {
        Task<TransacaoResponseDto> CriarAsync(CreateTransacaoDto dto);

        Task<List<TransacaoResponseDto>> ListarAsync();

    }
}
