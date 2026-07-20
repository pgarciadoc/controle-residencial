
using ControleResidencial.DTOs.Transacao;

namespace ControleResidencial.Services.Interfaces
{
    // Define o contrato das operações relacionadas às transações financeiras.
    public interface ITransacaoService
    {
        Task<TransacaoResponseDto> CriarAsync(CreateTransacaoDto dto);

        Task<List<TransacaoResponseDto>> ListarAsync();

    }
}
