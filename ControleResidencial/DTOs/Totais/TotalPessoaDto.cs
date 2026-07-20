namespace ControleResidencial.DTOs.Pessoa
{
    //DTO utilizado para representar os totais financeiros individuais de cada pessoa.
    public class TotalPessoaDto
    {
        //Para exibirmos o histórico completo da pessoa, precisamos:
        public int PessoaId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal Saldo { get; set; }

    }
}
