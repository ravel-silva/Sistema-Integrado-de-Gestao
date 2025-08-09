using Sistema_Integrado_de_Gestao.Application.Services;
using Sistema_Integrado_de_Gestao.Domain.Interfaces;
using Sistema_Integrado_de_Gestao.Infra.Data.Repositories;
using Sistema_Integrado_de_Gestao.Infra.IoC.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

//Injecoes
builder.Services.AddScoped<IEquipeRepository, EquipeRepository>(); // Inje��o do reposit�rio de equipe
builder.Services.AddScoped<EquipeService>(); // Inje��o do servi�o de equipe
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>(); // Inje��o do reposit�rio de funcion�rio
builder.Services.AddScoped<FuncionarioService>(); // Inje��o do servi�o de funcion�rio


builder.Services.AddAutoMapper(typeof(Program)); // AutoMapper configura��o
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();

// configura��o do banco de dados
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
