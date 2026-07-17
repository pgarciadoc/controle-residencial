using ControleResidencial.Models;

namespace ControleResidencial.DTOs.Transacao
{
    public class CreateTransacaoDto
    {
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public TipoTransacao Tipo { get; private set; }
        //chave estrangeira
        public int PessoaId { get; private set; }
    }
}
