using ControleResidencial.Data;
using ControleResidencial.DTOs.Pessoa;
using ControleResidencial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Runtime.CompilerServices;

namespace ControleResidencial.Services.Interfaces

{
    public class PessoaService : IPessoaService
    {
        private readonly AppDbContext _context;

        //Garantindo que a classe implementa a interface e que tudo compila, antes de construir a lógica
        public PessoaService(AppDbContext context)
        {
            _context = context;
          
        }

        public async Task<PessoaResponseDto?> BuscarPorIdAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            if (pessoa == null)
            {
                return null;
            }
   
            return new PessoaResponseDto
            {
              Id = pessoa.Id,
              Nome = pessoa.Nome,
              Idade = pessoa.Idade,
            };
            
        }


        //o método abaixo faz uma única responsabilidade. Ele nãoo sabe nada sobre HTTP, SWAGGER, REACT, etc.
        //Separando responsabilidades é um dos pilares de uma arquitetura limpa.
        public async Task<PessoaResponseDto> CriarPessoaAsync(CreatePessoaDto dto)
        {
            var pessoa = new Pessoa(dto.Nome, dto.Idade);

            _context.Pessoas.Add(pessoa);

            await _context.SaveChangesAsync();

            return new PessoaResponseDto
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Idade = pessoa.Idade,
            };
        }

        public Task ExcluirAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PessoaResponseDto>> ListarAsync()
        {
            throw new NotImplementedException();
        }
    }
}
