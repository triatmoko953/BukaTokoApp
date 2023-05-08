using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BukaToko.Data;
using BukaToko.Models;
namespace BukaToko.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly BukaTokoDbContext _context;

        public ProductRepo(BukaTokoDbContext context)
        {
            _context = context;
        }
        public async Task Create(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            _context.Products.Add(product);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Task Update(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
