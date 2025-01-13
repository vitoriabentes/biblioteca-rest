using Biblioteca_REST_API.Business;
using Biblioteca_REST_API.Business.Implementations;
using Biblioteca_REST_API.Models.Context;
using Biblioteca_REST_API.Repository;
using Biblioteca_REST_API.Repository.Generic;
using Biblioteca_REST_API.Repository.Implementations;
using EvolveDb;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options
.UseMySql(connection, new MySqlServerVersion(new Version(8,0,39))));

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

builder.Services.AddApiVersioning();

builder.Services.AddScoped<IRepository, PersonRepositoryImplementation>();
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookRepository, BookRepositoryImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "DB/Migrations", "DB/Dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}
