using System.ComponentModel.DataAnnotations;
using static PCBuilder.Common.ValidationConstants.MotherBoardConstants;

namespace PCBuilder.Data.Models
{
	public class MotherBoard
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(MaxNameLength)]
		public string Name { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		[Required]
		public int VendorId { get; set; }
		[Required]
		public CpuVendor Vendor { get; set; } = null!;

		[Required]
		public int CpuId { get; set; }

		public CPU CPU { get; set; } = null!;

		[Required]
		public int RamCapacity { get; set; }

	}
}
