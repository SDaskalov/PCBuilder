using System.ComponentModel.DataAnnotations;
using PCBuilder.Common.ValidationConstants
namespace PCBuilder.Data.Models

{
	public class Socket
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public virtual ICollection<CPU> CPUs { get; set; } = new List<CPU>();

	}
}
