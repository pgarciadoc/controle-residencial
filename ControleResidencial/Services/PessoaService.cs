using ControleResidencial.Data;
using ControleResidencial.DTOs.Pessoa;
using ControleResidencial.Models;
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

        public Task<PessoaResponseDto?> BuscarPorIdAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<PessoaResponseDto> ListarAsync()
        {
            throw new NotImplementedException();
        }
    }
}
