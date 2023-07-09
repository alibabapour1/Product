using Application.Abstractions;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products_CQRS.QueryHandler
{
    public class GetProductByIdHandler : IRequestHandler<GetProdoctById, Products>
    {
        private IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Products> Handle(GetProdoctById request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsById(request.Id);
        }
    }
}
