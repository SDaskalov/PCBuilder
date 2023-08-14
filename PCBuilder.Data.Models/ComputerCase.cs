using System.ComponentModel.DataAnnotations;
using static PCBuilder.Common.ValidationConstants.CaseConstants;

namespace PCBuilder.Data.Models
{
	public class ComputerCase
	{
		[Key]
        public int Id { get; set; }

		[Required]
		public string Name { get; set; } = null!;

		[Required]
		[MaxLength(MaxCaseImageLength)]
		public string ImageUrl { get; set; } = null!;

		[Required]
        public decimal Price { get; set; }

    }
}
