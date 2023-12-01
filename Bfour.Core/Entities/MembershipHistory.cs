using System;
namespace Bfour.Core.Entities
{
	public class MembershipHistory:BaseClass
	{
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int OldPackageCount { get; set; }
        public int NewPackageCount { get; set; }
        public DateTime ProcessDate { get; set; }

        public Member Member { get; set; }
        public Product Product { get; set; }

    }
}

