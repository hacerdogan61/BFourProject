using System;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bfour.Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContex appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsWithRelationsAsync()
        {
            return await _appDbContext.Product.AsNoTracking().Where(x=>!x.IsDeleted).ToListAsync();
        }
    }
}