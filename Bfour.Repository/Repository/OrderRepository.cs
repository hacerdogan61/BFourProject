using System;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bfour.Repository.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContex appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetListOrder()
        {
            return await _appDbContext.Order
                .AsNoTracking()
                .Include(x => x.OrderDetails)
                .ThenInclude(x => x.Product)
                .Include(x => x.PaymentType)
                .Include(x => x.Member)
                .Where(x => !x.IsDeleted)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _appDbContext.Order.AsNoTracking().Include(x => x.OrderDetails).Include(x => x.PaymentType).Include(x => x.Member).FirstOrDefaultAsync(x => !x.IsDeleted);
        }

        public async Task<Order> GetOrderByMemberId(int memberId)
        {
            return await _appDbContext.Order.AsNoTracking().Include(x => x.OrderDetails).Include(x => x.PaymentType).Include(x => x.Member).FirstOrDefaultAsync(x => x.MemberId == memberId && !x.IsDeleted);
        }


    }
}

