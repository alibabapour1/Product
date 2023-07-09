using Application.Abstractions;
using Application.Products_CQRS.Queries;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products_CQRS.QueryHandler
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, ICollection<Products>>
    {
        private IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICollection<Products>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllProducts();
        }
    }
}
