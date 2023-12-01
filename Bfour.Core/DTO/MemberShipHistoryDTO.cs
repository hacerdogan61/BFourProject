using System;
namespace Bfour.Core.DTO
{
	public class MemberShipHistoryDTO
	{
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int OldPackageCount { get; set; }
        public int NewPackageCount { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}

