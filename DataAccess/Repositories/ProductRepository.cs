using Application.Abstractions;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly MyDbcontext _ctx;
        public ProductRepository(MyDbcontext myDbcontext)
        {
            _ctx = myDbcontext;
        }
        public async Task<Products> CreateProducts(Products product)
        {
            product.ProduceDate = DateTime.Now;
            _ctx.Products.Add(product);
            await _ctx.SaveChangesAsync();
            return product;
            
        }

        public async Task DeleteProducts(int productid)
        {
            var product = await _ctx.Products.FirstOrDefaultAsync(p=>p.Id == productid);
            if (product == null) return;

            _ctx.Products.Remove(product);

            await _ctx.SaveChangesAsync();



        }

        public async Task<ICollection<Products>> GetAllProducts()
        {
           return await _ctx.Products.ToListAsync();
        }

        public async Task<Products> GetProductsById(int productid)
        {
            var product = await _ctx.Products.FirstOrDefaultAsync(p => p.Id == productid);
            return product;
        }

        public async Task<Products> UpdateProducts(Products product, int productid)
        {
            var p = await _ctx.Products.FirstOrDefaultAsync(p=>p.Id==productid);
            p.ManufacturePhone= product.ManufacturePhone;
            p.ManufactureEmail= product.ManufactureEmail;
            p.Name= product.Name;
            p.ProduceDate= DateTime.Now;
            p.IsAvailable= product.IsAvailable;
            p.Name = product.Name;
            await _ctx.SaveChangesAsync();
            return p;
        }
    }
}
