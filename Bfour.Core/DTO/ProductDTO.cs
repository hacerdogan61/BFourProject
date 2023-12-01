using System;
namespace Bfour.Core.DTO
{
	public class ProductDTO
	{
        public string Name { get; set; }
        public int SessionDurationByMinute { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}

