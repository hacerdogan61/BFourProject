using System;
using Bfour.Core.Entities;

namespace Bfour.Core.DTO
{
    public class MemberShipDTO
    {
        public int MemberId { get; set; }
        public int ProductId { get; set; }
        public int PackageCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

