
using ControleResidencial.DTOs.Pessoa;
using ControleResidencial.DTOs.Totais;

namespace ControleResidencial.Services.Interfaces
{
    // Define o contrato responsável pelo cálculo e consulta dos indicadores financeiros.
    public interface ITotalService
    {
    Task<TotaisResponseDto> ListarAsync();
    }
}
