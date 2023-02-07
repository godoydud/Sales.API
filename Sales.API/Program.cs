using Microsoft.EntityFrameworkCore;
using Sales.API.Application.Services;
using Sales.API.CrossCutting.DependencyInjection;
using Sales.API.Domain.Interfaces.Services;
using Sales.API.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<CoreContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=SalesControl;User Id=postgres;Password=admin;"));


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


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();