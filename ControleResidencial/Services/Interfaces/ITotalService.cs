
using ControleResidencial.DTOs.Pessoa;
using ControleResidencial.DTOs.Totais;

namespace ControleResidencial.Services.Interfaces
{
    public interface ITotalService
    {
    Task<TotaisResponseDto> ListarAsync();
    }
}
