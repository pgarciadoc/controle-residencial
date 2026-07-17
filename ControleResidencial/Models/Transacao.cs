
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleResidencial.Models
{
    [Table("transacoes")]
    public class Transacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor {  get; set; } 
        public TipoTransacao Tipo {  get; set; }
        //chave estrangeira
        public int PessoaId {  get; set; }

        //propriedade de navegação. Para o Entity Framework entender o relacionamento entre as entidades.
        public Pessoa Pessoa { get; set; } = null!;       

        public Transacao()
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
