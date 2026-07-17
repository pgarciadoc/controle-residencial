using ControleResidencial.Data;
using ControleResidencial.DTOs.Pessoa;
using ControleResidencial.Models;
using Microsoft.EntityFrameworkCore;


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

        public async Task<bool> ExcluirAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);

            //Verificando se a pessoa existe antes de tentar remover. Se não existir, retorna false.
            if (pessoa == null)
            {
                return false;
            }

            //Removendo a pessoa do contexto, mas não salvando ainda.
            _context.Pessoas.Remove(pessoa);
            //Salvando as alterações no banco de dados e verificando se alguma linha foi afetada.

            var linhasAfetadas = await _context.SaveChangesAsync();

            bool sucesso = linhasAfetadas > 0;

            return sucesso;

        }

        //Usando LINQ para mapear a lista de pessoas para uma lista de PessoaResponseDto
        public async Task<List<PessoaResponseDto>> ListarAsync()
        {

            var pessoa = await _context.Pessoas.ToListAsync();

            return pessoa
                .Select(p => new PessoaResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Idade = p.Idade,
            }).ToList();

        }
    }
}
