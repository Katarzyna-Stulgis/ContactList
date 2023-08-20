using ContactList.Api.Validators;
using ContactList.Dal.Context;
using ContactList.Dal.Repositories;
using ContactList.Domain.Interfaces;
using ContactList.Domain.Models;
using ContactList.Domain.Models.Entities;
using ContactList.Service.DataServices;
using ContactList.Service.Dtos;
using ContactList.Service.Profiles;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ContactlistDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name: "ContactlistOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services.AddAutoMapper(
    typeof(Program),
    typeof(ContactProfile),
    typeof(UserProfile)
    );

// DbContext
builder.Services.AddTransient<DbContext, ContactlistDbContext>();

// Configure JwtBearer authentication options.
var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});

// Add fluentValidation
builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
builder.Services.AddScoped<IValidator<LoginDto>, LoginDtoValidator>();

// Services Injection
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IContactCategoryService, ContactCategoryService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

// Repositories Injection
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactCategoryRepository, ContactCategoryRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ContactlistOrigins");

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
