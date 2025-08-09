using Sistema_Integrado_de_Gestao.Application.Services;
using Sistema_Integrado_de_Gestao.Domain.Interfaces;
using Sistema_Integrado_de_Gestao.Infra.Data.Repositories;
using Sistema_Integrado_de_Gestao.Infra.IoC.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

//Injecoes
builder.Services.AddScoped<IEquipeRepository, EquipeRepository>(); // Injeção do repositório de equipe
builder.Services.AddScoped<EquipeService>(); // Injeção do serviço de equipe
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>(); // Injeção do repositório de funcionário
builder.Services.AddScoped<FuncionarioService>(); // Injeção do serviço de funcionário


builder.Services.AddAutoMapper(typeof(Program)); // AutoMapper configuração
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();

// configuração do banco de dados
builder.Services.AddInfrastructure(builder.Configuration);

// referencia swagger
builder.Services.AddInfrastructureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
