using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IProductRepository
    {
        Task<ICollection<Products>> GetAllProducts();
        Task<Products> GetProductsById(int productid);
        Task<Products> CreateProducts(Products product);
        Task<Products> UpdateProducts(Products product, int productid);
        Task DeleteProducts(int productid);
    }
}
