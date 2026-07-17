using ControleResidencial.Data;
using ControleResidencial.DTOs.Transacao;
using ControleResidencial.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleResidencial.Services.Interfaces
{
    public class TransacaoService : ITransacaoService
    {
        private readonly AppDbContext _context;

        //Garantindo que a classe implementa a interface e que tudo compila, antes de construir a lógica
        public TransacaoService(AppDbContext context)
        {
            _context = context;

        }

        public async Task<TransacaoResponseDto> CriarAsync(CreateTransacaoDto dto)
        {
            var pessoa = await _context.Pessoas.FindAsync(dto.PessoaId);

            var transacao = new Transacao
            {
                Descricao = dto.Descricao,
                Valor = dto.Valor,
                Tipo = dto.Tipo,
                PessoaId = dto.PessoaId
            };

            if (pessoa == null) 
            {
                throw new Exception("A pessoa não existe");
            }

            if (pessoa.Idade < 18 && dto.Tipo == TipoTransacao.Receita)
            {
              throw new Exception("A pessoa não pode adicionar uma receita, pois é menor de idade");
            }

            _context.Transacoes.Add(transacao);

            await _context.SaveChangesAsync();

            return new TransacaoResponseDto
            {
                Id = transacao.Id,
                Descricao = transacao.Descricao,
                Valor = transacao.Valor,
                Tipo = transacao.Tipo,
                PessoaId = transacao.PessoaId
            };
        }

        public async Task<TransacaoResponseDto?> BuscarPorIdAsync(int id)
        {
            var transacao = await _context.Transacoes.FindAsync(id);

            if (transacao == null)
            {
                return null;
            }
   
            return new TransacaoResponseDto
            {
                Id = transacao.Id,
                Descricao = transacao.Descricao,
                Valor = transacao.Valor,
                Tipo = transacao.Tipo,
                PessoaId = transacao.PessoaId
            };
            
        }

        public async Task<List<TransacaoResponseDto>> ListarAsync()
        {
            var transacao = await _context.Transacoes.ToListAsync();

            return transacao
                .Select(p => new TransacaoResponseDto
            {
                Id = p.Id,
                Descricao = p.Descricao,
                Valor = p.Valor,
                Tipo = p.Tipo,
                PessoaId = p.PessoaId
            }).ToList();
        }
    }
}
