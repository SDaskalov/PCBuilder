
namespace PCBuilder.Web.ViewModels.GPU
{
    using System.ComponentModel.DataAnnotations;
    using static PCBuilder.Common.ValidationConstants.GPUConstants;
    public class GPUFormViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxNameLength)]
        public string ModelName { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Range(MinWatts, MaxWatts)]
        public int MaxWattage { get; set; }

        [MaxLength(MaxLinkLength)]
        public string ImageUrl { get; set; } = null!;

        public Guid BuilderId { get; set; }
    }

}
