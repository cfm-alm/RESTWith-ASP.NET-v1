using Microsoft.EntityFrameworkCore;
using RestwithASPNETUdemy.Model.Context;
using RestwithASPNETUdemy.Business;
using RestwithASPNETUdemy.Business.Implementations;
using RestwithASPNETUdemy.Repository;
using RestwithASPNETUdemy.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<Mysqlcontext>(options => options.UseMySql(connection, 
    new MySqlServerVersion(new Version(8, 2, 0))));

//Versionamento
builder.Services.AddApiVersioning();

// Dependency Injection

builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
