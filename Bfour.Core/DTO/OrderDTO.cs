using System;
namespace Bfour.Core.DTO
{
	public class OrderDTO
	{
        public int MemberId { get; set; }
        public int PaymentTypeId { get; set; }
        public string? PosName { get; set; }
        public decimal TotalUnitPrice { get; set; }
        public decimal TotalDiscountPrice { get; set; }
        public decimal? TotalNetSalePrice { get; set; }
        public decimal? DiscountRate { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}

