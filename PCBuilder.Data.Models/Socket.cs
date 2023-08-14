using System.ComponentModel.DataAnnotations;
using static PCBuilder.Common.ValidationConstants.Socket;

namespace PCBuilder.Data.Models

{
	public class Socket
	{
		public Socket()
		{
			this.CPUs = new List<CPU>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public virtual ICollection<CPU> CPUs { get; set; }

	}
}
