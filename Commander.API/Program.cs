using Commander.Domain.Repositories;
using Commander.Infrastructure.Data;
using Commander.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Commander.Application.Profiles;
using Commander.Domain.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using Commander.Application.Validation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer
    (builder.Configuration.GetConnectionString("CommanderConnection")));

builder.Services.AddControllers()
    .AddNewtonsoftJson(s =>
    {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CommandUpdateDtoValidator>();

// Replace AutoMapper registration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICommanderRepo, SqlCommanderRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the server URLs to use ports 5000/5001
builder.WebHost.UseUrls("http://localhost:5000", "https://localhost:5001");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
