using Application.Abstractions;
using Application.Products_CQRS.Commands;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products_CQRS.CommandHandler
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, Products>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Products> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var newprod = new Products()
            {
                Name = request.Name,
                ManufactureEmail = request.ManufactureEmail,
                ManufacturePhone=request.ManufacturePhone,
                IsAvailable=request.IsAvilable
            };

            return await _repository.CreateProducts(newprod);
        }
    }
}
