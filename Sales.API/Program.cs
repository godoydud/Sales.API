using Microsoft.EntityFrameworkCore;
using Npgsql;
using Sales.API.CrossCutting.DependencyInjection;
using Sales.API.Infra.Data.Context;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<CoreContext>(options =>
    options.UseNpgsql("Host=host.docker.internal;Port=5432;Pooling=true;Database=salesapi;User Id=postgres;Password=postgres;"));

builder.Services.AddScoped<IDbConnection>(sp =>
    new NpgsqlConnection("Host=host.docker.internal;Port=5432;Pooling=true;Database=salesapi;User Id=postgres;Password=postgres;"));


ConfigureService.Configure(builder.Services);
ConfigureRepositories.Configure(builder.Services, builder.Configuration);
ConfigureMappers.Configure(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(c => c
    .AllowAnyOrigin()
       .AllowAnyMethod()
          .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();