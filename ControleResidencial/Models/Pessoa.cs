using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleResidencial.Models
{
    // Representa uma pessoa cadastrada no sistema.
    // Cada pessoa pode possuir uma ou mais transações financeiras.
    [Table("pessoas")]
    public class Pessoa
    {
        // Identificador único da pessoa.
        public int Id { get; set; }
        // Nome completo da pessoa.
        public string Nome { get; set; } = string.Empty;
        // Idade utilizada para aplicação das regras de negócio.
        public int Idade { get; set; }

        //Propriedade de navegação. Para o Entity Framework entender o relacionamento entre as entidades.
        // Relacionamento um-para-muitos entre Pessoa e Transação.
        public ICollection<Transacao> Transacoes { get; set; }
            = new List<Transacao>();

        //encapsulamento para que não seja criada uma Pessoa sem nome e idade
        public Pessoa(string nome, int idade)
        {
            this.Nome = nome;
            this.Idade = idade;
        }

        //construtor vazio, cujo objetivo é permitir que o Entity Framework faça seu trabalho.
        public Pessoa()
        {

        }
    }
}
