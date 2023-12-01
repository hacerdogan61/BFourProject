using System;
namespace Bfour.Core.Entities
{
    public class OrderDetail : BaseClass
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int PackageCount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal NetSalePrice { get; set; }
        public decimal DiscountRate { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
        public int MemberShipId { get; set; }
        public MemberShip Membership { get; set; }
    }
}

