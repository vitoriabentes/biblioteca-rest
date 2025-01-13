using Biblioteca_REST_API.Models.Context;
using Biblioteca_REST_API.Services;
using Biblioteca_REST_API.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options
.UseMySql(connection, new MySqlServerVersion(new Version(8,0,39))));

builder.Services.AddApiVersioning();

builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
