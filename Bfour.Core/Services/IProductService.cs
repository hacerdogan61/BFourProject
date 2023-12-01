using Bfour.Core.Entities;
using Bfour.Core.ResultModel;

namespace Bfour.Core.Services
{
	public interface IProductService:IServices<Product>
    {
        Task<Result<IEnumerable<Product>>> GetProductsWithRelationsAsync();
    }
}

