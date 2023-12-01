using System;
using System.ComponentModel.DataAnnotations;

namespace Bfour.Core.Entities
{
	public abstract class BaseClass
	{
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }

    }
}

