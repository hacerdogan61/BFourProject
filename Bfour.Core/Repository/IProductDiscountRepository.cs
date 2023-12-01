using System;
using Bfour.Core.Entities;

namespace Bfour.Core.Repository
{
	public interface IProductDiscountRepository : IGenericRepository<ProductDiscount>
    {
        Task<IEnumerable<Product>> GetProductsDiscountPackageCount();

    }
}

