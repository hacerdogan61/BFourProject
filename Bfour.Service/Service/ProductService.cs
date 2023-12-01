using System;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Bfour.Core.ResultModel;
using Bfour.Core.Services;
using Bfour.Core.UnitOfWorks;
using Bfour.Repository.Repository;

namespace Bfour.Service.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWorks unitOfWorks, IProductRepository productRepository) : base(repository, unitOfWorks)
        {
            _productRepository = productRepository;
        }

        public async Task<Result<IEnumerable<Product>>> GetProductsWithRelationsAsync()
        {
            var product = await _productRepository.GetProductsWithRelationsAsync();
            return Result<IEnumerable<Product>>.Success(200, product, true);
        }
    }
}

