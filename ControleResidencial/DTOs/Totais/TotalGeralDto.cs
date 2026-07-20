namespace ControleResidencial.DTOs.Totais
{
    //DTO utilizado para representar os indicadores financeiros consolidados da aplicação.
    public class TotalGeralDto
    {
        public decimal TotalReceitas { get; set; }

        public decimal TotalDespesas { get; set; }

        public decimal SaldoLiquido { get; set; }
    }
}