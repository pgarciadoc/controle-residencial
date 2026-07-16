
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleResidencial.Models
{
    [Table("transacoes")]
    public class Transacao
    {
        public int Id { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor {  get; private set; } 
        public TipoTransacao Tipo {  get; private set; }
        //chave estrangeira
        public int PessoaId {  get; private set; }

        //propriedade de navegação. Para o Entity Framework entender o relacionamento entre as entidades.
        public Pessoa Pessoa { get; private set; } = null!;       

        private Transacao()
        {
            
        }

        public Transacao(string descricao, decimal valor, TipoTransacao tipo, int pessoaId)
        {
            this.Descricao = descricao;
            this.Valor = valor;
            this.Tipo = tipo;
            this.PessoaId = pessoaId;
        }
    }
}
