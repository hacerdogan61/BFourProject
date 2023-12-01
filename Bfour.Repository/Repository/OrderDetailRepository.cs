using System;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bfour.Repository.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(AppDbContex appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<OrderDetail>> GetListOrderDetailAsync()
        {
            return await _appDbContext.OrderDetail.AsNoTracking().Include(x => x.Product).Include(x => x.Order).Where(x=>!x.IsDeleted).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailByIdAsync(int id)
        {
            return await _appDbContext.OrderDetail.AsNoTracking().Include(x => x.Product).Include(x => x.Order).Include(x=>x.Membership).FirstOrDefaultAsync(x => x.Id == id &&!x.IsDeleted );
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByMemberShipIdAsync(int memberShipId)
        {
            return await _appDbContext.OrderDetail.AsNoTracking().Include(x => x.Membership).Where(x=>!x.IsDeleted).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderIdAsync(int orderId)
        {
            return await _appDbContext.OrderDetail.AsNoTracking().Include(x => x.Product).Include(x => x.Order).Where(x=>x.OrderId==orderId && !x.IsDeleted).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByProductIdAsync(int productId)
        {
            return await _appDbContext.OrderDetail.AsNoTracking().Include(x => x.Product).Where(x => x.ProductId==productId && !x.IsDeleted).OrderBy(x => x.Id).ToListAsync();
        }
    }
}

