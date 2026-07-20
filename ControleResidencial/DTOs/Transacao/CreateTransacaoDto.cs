using ControleResidencial.Models;

namespace ControleResidencial.DTOs.Transacao
{
    //DTO utilizado para receber os dados necessários para o cadastro de uma nova transação.
    public class CreateTransacaoDto
    {
    
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao Tipo { get; set; }
        //chave estrangeira
        public int PessoaId { get; set; }
        public string PessoaNome { get; set; } = string.Empty;

    }
}
