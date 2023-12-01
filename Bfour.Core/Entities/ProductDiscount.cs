using System;
namespace Bfour.Core.Entities
{
	public class ProductDiscount:BaseClass
	{
		public int TotalProductCount { get; set; }
		public int PackageCount { get; set; }
		public int DiscountRate { get; set; }
	}
}

