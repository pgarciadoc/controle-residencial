
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleResidencial.Models
{
    // Representa uma movimentação financeira vinculada a uma pessoa.
    // Pode ser classificada como Receita ou Despesa.
    [Table("transacoes")]
    public class Transacao
    {
        // Identificador único da transação.
        public int Id { get; set; }
        // Descrição da movimentação financeira.
        public string Descricao { get; set; }
        // Valor monetário da transação.
        public decimal Valor {  get; set; } 
        // Classificação da transação (Receita ou Despesa).
        public TipoTransacao Tipo {  get; set; }
        //chave estrangeira
        public int PessoaId {  get; set; }

        //propriedade de navegação. Para o Entity Framework entender o relacionamento entre as entidades.
        public Pessoa Pessoa { get; set; } = null!;       

        public Transacao()
        {
            
        }

        // Inicializa uma transação com os dados necessários para cadastro.
        public Transacao(string descricao, decimal valor, TipoTransacao tipo, int pessoaId)
        {
            this.Descricao = descricao;
            this.Valor = valor;
            this.Tipo = tipo;
            this.PessoaId = pessoaId;
        }
    }
}
