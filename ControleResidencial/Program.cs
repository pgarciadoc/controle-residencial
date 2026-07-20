using ControleResidencial.Data;
using ControleResidencial.Services;
using ControleResidencial.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

// Cria o builder da aplicação ASP.NET Core,
// responsável por configurar serviços e pipeline HTTP.
var builder = WebApplication.CreateBuilder(args);

// Configuração do Entity Framework Core utilizando SQLite
// como banco de dados da aplicação.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra os serviços essenciais da API.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro das dependências utilizando Injeção de Dependência (DI).
// Cada interface é associada à sua implementação concreta.
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<ITotalService, TotaisService>();

// Política de CORS para permitir que o frontend React
// consuma a API durante o desenvolvimento.
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Constrói a aplicação.
var app = builder.Build();

// Habilita a política de CORS configurada anteriormente.
app.UseCors("ReactPolicy");

// Disponibiliza a documentação da API via Swagger
// apenas em ambiente de desenvolvimento.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona automaticamente requisições HTTP para HTTPS.
app.UseHttpsRedirection();
// Middleware responsável pela autorização das requisições.
app.UseAuthorization();
// Mapeia automaticamente todos os Controllers da aplicação.
app.MapControllers();
// Inicializa a API.
app.Run();

