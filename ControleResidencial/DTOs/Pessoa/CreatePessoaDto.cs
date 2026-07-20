namespace ControleResidencial.DTOs.Pessoa
{
    //DTO utilizado para receber os dados necessários para o cadastro de uma nova pessoa.
    public class CreatePessoaDto
    {
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
    }
}
