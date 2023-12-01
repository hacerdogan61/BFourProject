using System;
namespace Bfour.Core.Entities
{
	public class MemberShip:BaseClass
    {
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int PackageCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Member Member { get; set; }
        public Product Product { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }

    }
}

