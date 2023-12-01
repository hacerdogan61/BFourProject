using System;
using System.Linq.Expressions;
using Bfour.Core.ResultModel;

namespace Bfour.Core.Services
{
	public interface IServices<T> where T:class
	{
        Task<Result<T>> GetByIdAsync(int id);
        Result<IQueryable<T>> GetAll();
        Result<IQueryable<T>> Where(Expression<Func<T, bool>> expression);
        Task<Result<bool>> AnyAsync(Expression<Func<T, bool>> expression);
        Task<Result<T>> AddAsync(T entity);
        Task<Result<IEnumerable<T>>> AddRangeAsync(IEnumerable<T> Entity);
        Task<Result<T>> UpdateAsync(T entity);
        Task<Result<T>> RemoveAsync(T entity);
        Task<Result<T>> RemoveRangeAsync(IEnumerable<T> Entity);
    }
}

