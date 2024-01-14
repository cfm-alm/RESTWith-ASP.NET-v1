using Microsoft.EntityFrameworkCore;
using EvolveDb;
using Serilog;
using MySqlConnector;
using RestwithASPNETUdemy.Business.Implementations;
using RestwithASPNETUdemy.Business;
using RestwithASPNETUdemy.Model.Context;
using RestwithASPNETUdemy.Repository;
using RestwithASPNETUdemy.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<Mysqlcontext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 0, 29)))
);

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

//Versioning API
builder.Services.AddApiVersioning();

//Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();

builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

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
            Locations = new List<string> { "db/migrations", "db/dataset" },
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