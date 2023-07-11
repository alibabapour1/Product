using Application.Abstractions;
using Application.Products_CQRS.Commands;
using DataAccess;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Application.Products_CQRS.QueryHandler;
using System.Runtime.CompilerServices;
using Domain;
using Application.Products_CQRS.Queries;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbcontext>(opt=>opt.UseSqlServer(cs));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateProduct)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

    app.MapGet("/api/Products/{Id}", async (IMediator mediator,int Id) =>
    {
        var getproduct = new GetProdoctById {Id = Id };
        var Product = await mediator.Send(getproduct);
        return Results.Ok(Product);
    }).WithName("GetProductById");

    app.MapPost("/api/Products", async (IMediator mediator, Products product) =>
    {
        var createProduct = new CreateProduct 
        {
            //ManufactureEmail=product.ManufactureEmail,
            //ManufacturePhone=product.ManufacturePhone,
            //Name=product.Name,
            //IsAvilable=product.IsAvailable
        };
        var CreatedProduct = await mediator.Send(createProduct);
        return Results.CreatedAtRoute("GetProductById", new { CreatedProduct.Id }, CreatedProduct);

    });

    app.MapGet("/api/Products", async (IMediator mediator) =>
    {
        var getAllPro = new GetAllProducts ();
        var Products = await mediator.Send(getAllPro);
        return Results.Ok(Products);
    });

    app.MapPut("/api/Products/{Id}", async (IMediator mediator,int Id,Products product) => 
    {
        var UpdateProduct = new UpdateProduct { Id = Id, Name = product.Name, ManufactorEmail=product.ManufactureEmail };
        var UpdatedProducts = await mediator.Send(UpdateProduct);
        return Results.Ok(UpdatedProducts); 
    });

    app.MapDelete("/api/Products/{Id}", async (IMediator mediator,int Id) =>
    {
        var DeleteProduct = new DeleteProduct {  Id = Id };
        await mediator.Send(DeleteProduct);
        return Results.NoContent();
    });




app.Run();

 
