using System;
namespace Bfour.Core.DTO
{
    public class OrderDetailDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int PackageCount { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal NetSalePrice { get; set; }
        public decimal DiscountRate { get; set; }
        public string? Name { get; set; }
    }
}