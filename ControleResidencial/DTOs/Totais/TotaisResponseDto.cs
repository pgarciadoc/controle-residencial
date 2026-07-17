using ControleResidencial.DTOs.Pessoa;

namespace ControleResidencial.DTOs.Totais
{
    public class TotaisResponseDto
    {
        public List<TotalPessoaDto> Pessoas { get; set; } = new();
        public TotalGeralDto TotalGeral { get; set; } = new();
    }
}