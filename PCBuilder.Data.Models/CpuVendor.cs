using System.ComponentModel.DataAnnotations;

namespace PCBuilder.Data.Models
{
	public class CpuVendor
	{

		[Key]
        public int Id { get; set; }

		[Required]
		public string Name { get; set; } = null!;

    }
}