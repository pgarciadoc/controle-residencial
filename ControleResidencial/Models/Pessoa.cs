using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleResidencial.Models
{
    [Table("pessoas")]
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }

        //propriedade de navegação. Para o Entity Framework entender o relacionamento entre as entidades
        public ICollection<Transacao> Transacoes { get; set; }
            = new List<Transacao>();

        //encapsulamento para que não seja criada uma Pessoa sem nome e idade
        public Pessoa(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;
        }


        //construtor vazio, cujo objetivo é permitir que o Entity Framework faça seu trabalho
        public Pessoa()
        {

        }
    }
}
