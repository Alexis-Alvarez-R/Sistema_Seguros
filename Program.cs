using Microsoft.EntityFrameworkCore;
using Sistema_Emision_Seguros.Data;
using Sistema_Emision_Seguros.Repository;
using Sistema_Emision_Seguros.Repository.IRepository;
using Sistema_Emision_Seguros.Service;
using Sistema_Emision_Seguros.Service.IService;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Cadena de conexion

var dbConnectionString = builder.Configuration.GetConnectionString("ConexionSql");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnectionString));

//Repositorios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICoberturaRepository, CoberturaRepository>();
builder.Services.AddScoped<IPolizaRepository, PolizaRepository>();

// Servicios 
builder.Services.AddScoped<IPolizaService, PolizaService>();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(Program).Assembly);
});

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
