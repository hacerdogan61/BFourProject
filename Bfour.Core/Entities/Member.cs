using System;
namespace Bfour.Core.Entities
{
	public class Member:BaseClass
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string? IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }

        public List<Order> Orders { get; set; }
        public List<MemberAppointment> Appointments { get; set; }
    }
}

