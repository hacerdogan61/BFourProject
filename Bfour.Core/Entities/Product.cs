using System;
namespace Bfour.Core.Entities
{
	public class Product:BaseClass
	{
        public string Name { get; set; }
        public int SessionDurationByMinute { get; set; }
        public decimal Price { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<MemberShip> Memberships { get; set; }
        public List<MembershipHistory> MembershipHistories { get; set; }
        public List<MemberAppointment> Appointments { get; set; }
    }
}

