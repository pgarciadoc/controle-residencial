using ControleResidencial.Models;

namespace ControleResidencial.DTOs.Transacao
{
    //DTO utilizado para retornar os dados de uma transação cadastrada.
    public class TransacaoResponseDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        //chave estrangeira
        public int PessoaId { get; set; }
        public string PessoaNome { get; set; } = string.Empty;

    }
}
