using System;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bfour.Repository.Repository
{
    public class MemberShipRepository : GenericRepository<MemberShip>, IMemberShipRepository
    {
        public MemberShipRepository(AppDbContex appDbContext) : base(appDbContext)
        {
        }

        public async Task<List<MemberShip>> GetMemberShipAsync()
        {
            return await _appDbContext.MemberShip.Include(x=>x.OrderDetail).Where(x => EF.Property<bool>(x, "IsDeleted") == false).AsNoTracking().ToListAsync();
        }
    }
}

