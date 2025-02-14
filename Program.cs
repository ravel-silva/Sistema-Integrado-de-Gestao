using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Model.Auth;
using Solicitacao_de_Material.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<RelationShipEquipeFuncionarioService>();
builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<RequisicaoDeMaterialService>();
builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<UserService>();

// configuraçao para evitar loop infinito
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
}); 

// permite letras maisculas e minusculas e espaços no campo de username
builder.Services.Configure<IdentityOptions>(options =>
{
   options.User.AllowedUserNameCharacters= "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
});

// Add services to the container.

//configuraçao do banco de dados
var connectionString = builder.Configuration.GetConnectionString("EquipeConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

