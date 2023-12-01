using System;
namespace Bfour.Core.Entities
{
	public class MemberAppointment:BaseClass
    {
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsCompleted { get; set; }
        public string Note { get; set; }

        public Member Member { get; set; }
        public Product Product { get; set; }

    }
}

