using System;
using Bfour.Core.Entities;

namespace Bfour.Core.Repository
{
	public interface IProductRepository : IGenericRepository<Product>
    {

		Task<IEnumerable<Product>> GetProductsWithRelationsAsync();
	}
}

