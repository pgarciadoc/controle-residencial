using ControleResidencial.DTOs.Pessoa;

namespace ControleResidencial.DTOs.Totais
{
    //DTO responsável por agrupar os totais por pessoa e os indicadores gerais retornados pelo endpoint de totais.
    public class TotaisResponseDto
    {
        public List<TotalPessoaDto> Pessoas { get; set; } = new();
        public TotalGeralDto TotalGeral { get; set; } = new();

    }
}