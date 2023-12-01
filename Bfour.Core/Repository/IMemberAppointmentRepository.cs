using System;
using Bfour.Core.Entities;

namespace Bfour.Core.Repository
{
	public interface IMemberAppointmentRepository : IGenericRepository<MemberAppointment>
    {
        Task<IEnumerable<MemberAppointment>> GetMemberAppointmentsAsync();
    }
}

