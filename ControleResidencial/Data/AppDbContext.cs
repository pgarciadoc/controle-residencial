using Microsoft.EntityFrameworkCore;
using ControleResidencial.Models;

namespace ControleResidencial.Data

{
    // Contexto de acesso ao banco de dados da aplicação.
    // Responsável por mapear as entidades para as tabelas e permitir
    // que o Entity Framework Core realize operações de persistência.
    public class AppDbContext : DbContext
    {
        // Recebe as configurações do contexto (connection string,
        // provedor do banco, etc.) definidas no Program.cs.
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        // Representa a tabela de pessoas.
        public DbSet<Pessoa> Pessoas { get; set; }
        // Representa a tabela de transações financeiras.
        public DbSet<Transacao> Transacoes { get; set; }
    }
}
