using Application.Abstractions;
using Application.Products_CQRS.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products_CQRS.CommandHandler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct>
    {
        private readonly IProductRepository _repository;

        public DeleteProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            await _repository.DeleteProducts(request.Id);
            
        }
    }
}
