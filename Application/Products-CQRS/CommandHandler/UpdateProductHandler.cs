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
    

    public class UpdateProductHandler : IRequestHandler<UpdateProduct, Products>
    {
        private readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Products> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var UpdatedName = new Products()
            {
                Name = request.Name,
            };
            return await _repository.UpdateProducts(UpdatedName, request.Id);
        }
    }
}
 