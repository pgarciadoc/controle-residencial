
namespace ControleResidencial.DTOs.Pessoa
{
    //DTO utilizado para retornar as informações de uma pessoa ao cliente da API.
    public class PessoaResponseDto
    {
        //Inserindo o que o programa deve devolver ao usuário quando o mesmo decide criar uma pessoa

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }


    }
}
