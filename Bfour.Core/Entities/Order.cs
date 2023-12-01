using System;
namespace Bfour.Core.Entities
{
    public class Order : BaseClass
    {
        public int MemberId { get; set; }
        public int PaymentTypeId { get; set; }
        public string? PosName { get; set; }
        public decimal? TotalUnitPrice { get; set; }
        public decimal? TotalDiscountPrice { get; set; }
        public decimal? TotalNetSalePrice { get; set; }
        public decimal? DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Member Member { get; set; }
        public PaymentType PaymentType { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}