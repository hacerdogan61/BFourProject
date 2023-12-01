using System;
using System.Linq.Expressions;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Bfour.Core.ResultModel;
using Bfour.Core.Services;
using Bfour.Core.UnitOfWorks;

namespace Bfour.Service.Service
{
	public class Service<T>:IServices<T> where T:class
	{
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWorks _unitOfWorks;

		public Service(IGenericRepository<T> repository, IUnitOfWorks unitOfWorks)
		{
            _repository = repository;
            _unitOfWorks = unitOfWorks;
		}

        public async Task<Result<T>> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWorks.CommitAsync();
            return Result<T>.Success(200, entity, true);
        }

        public async Task<Result<IEnumerable<T>>> AddRangeAsync(IEnumerable<T> Entity)
        {
            await _repository.AddRangeAsync(Entity);
            await _unitOfWorks.CommitAsync();
            return Result<IEnumerable<T>>.Success(200, Entity, true);
        }

        public async Task<Result<bool>> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return  Result<bool>.Success(200, await _repository.AnyAsync(expression),true);
        }

        public Result<IQueryable<T>> GetAll()
        {
            return Result<IQueryable<T>>.Success(200,_repository.GetAll(),true);
        }

        public async Task<Result<T>> GetByIdAsync(int id)
        {
            return Result <T>.Success(200,await _repository.GetByIdAsync(id),true);
        }

        public async Task<Result<T>> RemoveAsync(T entity)
        {
             _repository.Remove(entity);
            await _unitOfWorks.CommitAsync();
            return Result<T>.Success(200,true);
        }

        public async Task<Result<T>> RemoveRangeAsync(IEnumerable<T> Entity)
        {
            _repository.RemoveRange(Entity);
            await _unitOfWorks.CommitAsync();
            return Result<T>.Success(200, true);
        }

        public async Task<Result<T>> UpdateAsync(T entity)
        {
           ;
            _repository.Update(entity);
            await _unitOfWorks.CommitAsync();
            return Result<T>.Success(200, true);
        }

        public Result<IQueryable<T>> Where(Expression<Func<T, bool>> expression)
        {
            return Result<IQueryable<T>>.Success(200,_repository.Where(expression),true);
        }
    }
}

