using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Solicitacao_de_Material.Data;
using Solicitacao_de_Material.Services;

var builder = WebApplication.CreateBuilder(args);

//-->
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//-->

//teste de hospedagem
var port = Environment.GetEnvironmentVariable("PORT") ?? "5005";
builder.WebHost.UseUrls($"http://*:{port}");




builder.Services.AddScoped<TeamService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<RelationShipEquipeFuncionarioService>();
builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<RequisicaoDeMaterialService>();
//builder.Services.AddIdentity<Usuario, IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>()
//    .AddDefaultTokenProviders();

// Configurar políticas de autorização
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Basico", policy => policy.RequireRole("Basico"));
    options.AddPolicy("Administrador", policy => policy.RequireRole("Administrador"));
});


// configuraçao para evitar loop infinito
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

// permite letras maisculas e minusculas e espaços no campo de username
builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
});

// Add services to the container.

//configuraçao do banco de dados
var connectionString = builder.Configuration.GetConnectionString("EquipeConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.UseCors(); // excluir depois

app.MapControllers();



app.Run();

