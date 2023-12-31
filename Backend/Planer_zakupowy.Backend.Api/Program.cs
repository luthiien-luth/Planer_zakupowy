using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Planer_zakupowy.Backend.Api;
using Planer_zakupowy.Backend.Api.Factories;
using Planer_zakupowy.Backend.Api.Factories.Interfaces;
using Planer_zakupowy.Backend.Application.Interfaces;
using Planer_zakupowy.Backend.Application.Repositories;
using Planer_zakupowy.Backend.Application.Services;
using Planer_zakupowy.Backend.Application.Validator;
using Planer_zakupowy.Backend.DataAccess;
using Planer_zakupowy.Backend.DataAccess.Factories;
using Planer_zakupowy.Backend.DataAccess.Factories.Interfaces;
using Planer_zakupowy.Backend.DataAccess.Repositories;
using Planer_zakupowy.Backend.DataAccess.Seeder;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DBConnection");
var allowSpecificOrigins = "allowSpecificOrigins";

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
                      policy =>
                      {
                          policy
                          .WithOrigins("http://localhost:3000",
                              "http://localhost:4200")
                          .WithMethods("GET", "POST")
                          .AllowAnyHeader();
                      });
});
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlanerZakupowyDbContext>(opt => opt.UseSqlServer(connection));
builder.Services.AddTransient<IUserFactory, UserFactory>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IValidator, Validator>();
builder.Services.AddTransient<IUserDbFactory, UserDbFactory>();
builder.Services.AddScoped<ProductsSeeder>();
builder.Services.AddTransient<ErrorHandlingMiddleware>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<ProductsSeeder>();
await seeder.Seed();

app.UseCors(allowSpecificOrigins);
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Planer zakupowy");
    c.RoutePrefix = string.Empty;
});

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();

app.Run();
