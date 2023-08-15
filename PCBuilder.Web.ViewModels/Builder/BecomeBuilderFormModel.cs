namespace PCBuilder.Web.ViewModels.Builder
{
    using System.ComponentModel.DataAnnotations;
    using static PCBuilder.Common.ValidationConstants.BuilderConstants;
    public class BecomeBuilderFormModel
    {
        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        [Display(Name = "Public builder name")]
        public string PublicBuilderName { get; set; } = null!;
    }
}
