using ControleResidencial.DTOs.Pessoa;

namespace ControleResidencial.Services.Interfaces
{
    public interface IPessoaService
    {
        //recebe CreatePessoaDto e retorna PessoaResponseDto
        Task<PessoaResponseDto> CriarPessoaAsync(CreatePessoaDto dto);
        //recebe id e retorna PessoaResponseDto. Se não existir, retorna null, ou melhor, uma exceção tratada
        Task<PessoaResponseDto?> BuscarPorIdAsync(int id);
        //retorna List<PessoaResponseDto>
        Task<List<PessoaResponseDto>> ListarAsync();
        //recebe apenas id, sem nenhum retorno
        Task<bool> ExcluirAsync(int id);


        //Usamos async porque o EntityFramework trabalha muito com operações assíncronas. Por isso que a interface retorna Task< >
    }
}
