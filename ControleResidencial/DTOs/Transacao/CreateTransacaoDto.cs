using ControleResidencial.Models;

namespace ControleResidencial.DTOs.Transacao
{
    public class CreateTransacaoDto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        //chave estrangeira
        public int PessoaId { get; set; }
    }
}
