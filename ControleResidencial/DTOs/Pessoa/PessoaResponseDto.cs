
namespace ControleResidencial.DTOs.Pessoa
{
    public class PessoaResponseDto
    {
        //Inserindo o que o programa deve devolver ao usuário quando o mesmo decide criar uma pessoa

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }


    }
}
