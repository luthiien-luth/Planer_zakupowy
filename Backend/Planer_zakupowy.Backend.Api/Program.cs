using Microsoft.EntityFrameworkCore;
using Planer_zakupowy.Backend.Api;
using Planer_zakupowy.Backend.Api.Factories;
using Planer_zakupowy.Backend.Api.Factories.Interfaces;
using Planer_zakupowy.Backend.Application.Interfaces;
using Planer_zakupowy.Backend.Application.Repositories;
using Planer_zakupowy.Backend.Application.Services;
using Planer_zakupowy.Backend.Application.Validator;
using Planer_zakupowy.Backend.DataAccess;
using Planer_zakupowy.Backend.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DBConnection");

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Planer_zakupowyDbContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddTransient<IUserFactory, UserFactory>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IValidator, Validator>();
builder.Services.AddTransient<ErrorHandlingMiddleware>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planer zakupowy");
    c.RoutePrefix = string.Empty;
});

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();

app.Run();
