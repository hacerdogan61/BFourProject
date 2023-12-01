using System;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Bfour.Repository.Repository
{
    public class MemberAppointmentRepository : GenericRepository<MemberAppointment>, IMemberAppointmentRepository
    {
        public MemberAppointmentRepository(AppDbContex appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<MemberAppointment>> GetMemberAppointmentsAsync()
        {
            return await _appDbContext.MemberAppointment.Include(x => x.Member).Include(x => x.Product).Where(x => EF.Property<bool>(x, "IsDeleted") == false).OrderByDescending(x => x.Id).ToListAsync();
        }
    }

}