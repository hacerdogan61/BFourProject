using System;
namespace Bfour.Core.DTO
{
	public class MemberAppointmentDTO
	{
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Note { get; set; }
    }
}

