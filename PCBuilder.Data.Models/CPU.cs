using System.ComponentModel.DataAnnotations;
using static PCBuilder.Common.ValidationConstants.CpuConstants;

namespace PCBuilder.Data.Models
{
	public class CPU
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength()]
		public string ModelName { get; set; } = null!;

		[Required]
		[Range(MinPrice, MaxPrice)]
		public decimal Price { get; set; }

		[Required]
        public int VendorId { get; set; }
        [Required]
		public CpuVendor Vendor { get; set; } = null!;
	}
}