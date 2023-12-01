using System;
using Bfour.Core.Entities;
using Bfour.Core.ResultModel;

namespace Bfour.Core.Services
{
	public interface IMemberAppointmentService : IServices<MemberAppointment>
    {
		Task<Result<IEnumerable<MemberAppointment>>> GetMemberAppointmentAllAsync();
        Result<MemberAppointment> GetMemberAppointmentById(int id);
    }
}

