using Application.Abstractions;
using Application.Products_CQRS.Commands;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbcontext>(opt=>opt.UseSqlServer(cs));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(typeof(CreateProduct));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();






app.Run();

 
