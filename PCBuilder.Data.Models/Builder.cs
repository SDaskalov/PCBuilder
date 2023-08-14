using System.ComponentModel.DataAnnotations;
using static PCBuilder.Common.ValidationConstants.BuilderConstants;
namespace PCBuilder.Data.Models
{
	public class Builder
	{
		[Key]
        public Guid Id { get; set; }

        public Builder()
        {
            this.Id = Guid.NewGuid();
            this.Builds= new List<PCConfiguration>();
        }

        [Required]
		[MaxLength(MaxNameLength)]
		public string PublicBuilderName { get; set; } = null!;

        public Guid UserId { get; set; }

		public virtual ApplicationUser User { get; set; } = null!;

        public ICollection<PCConfiguration> Builds { get; set; } = null!;
    }
}