using Microsoft.EntityFrameworkCore;
using Planer_zakupowy.Backend.Api.Factories;
using Planer_zakupowy.Backend.Api.Factories.Interfaces;
using Planer_zakupowy.Backend.DataAccess;
using Planer_zakupowy.Backend.DataAccess.Repositories;
using Planer_zakupowy.Backend.Domain.Interfaces;
using Planer_zakupowy.Backend.Domain.Repositories;
using Planer_zakupowy.Backend.Domain.Services;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DBConnection");

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Planer_zakupowyDbContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddTransient<IUserFactory, UserFactory>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planer zakupowy");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
