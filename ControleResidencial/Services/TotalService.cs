using ControleResidencial.Data;
using ControleResidencial.DTOs.Pessoa;
using ControleResidencial.DTOs.Totais;
using ControleResidencial.Models;
using ControleResidencial.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

public class TotaisService : ITotalService
{
    private readonly AppDbContext _context;

    public TotaisService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TotaisResponseDto> ListarAsync()
    {
        var pessoas = await _context.Pessoas
            .Include(p => p.Transacoes)
            .ToListAsync();

        var totaisPessoas =  pessoas.Select(p => new TotalPessoaDto
        {
            PessoaId = p.Id,
            Nome = p.Nome,

            TotalReceitas = p.Transacoes
                .Where(t => t.Tipo == TipoTransacao.Receita)
                .Sum(t => t.Valor),

            TotalDespesas = p.Transacoes
                .Where(t => t.Tipo == TipoTransacao.Despesa)
                .Sum(t => t.Valor),

            Saldo =
                p.Transacoes
                    .Where(t => t.Tipo == TipoTransacao.Receita)
                    .Sum(t => t.Valor)
                -
                p.Transacoes
                    .Where(t => t.Tipo == TipoTransacao.Despesa)
                    .Sum(t => t.Valor)

        }).ToList();

        var totalGeral = new TotalGeralDto
        {
            TotalReceitas = totaisPessoas.Sum(p => p.TotalReceitas),
            TotalDespesas = totaisPessoas.Sum(p => p.TotalDespesas),
            SaldoLiquido = totaisPessoas.Sum(p => p.Saldo)
        };

        return new TotaisResponseDto
        {
            Pessoas = totaisPessoas,
            TotalGeral = totalGeral
        };
    }
}

