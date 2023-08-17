
namespace PCBuilder.Web.ViewModels.PCConfiguration
{
    using System.ComponentModel.DataAnnotations;
    
    public class PCBuildDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;


        public string HighestBid { get; set; } = null!;

        [Required]
        public int CpuId { get; set; }

        [Required]
        public int CaseId { get; set; }

        public int GpuId { get; set; }

        [Required]
        public int MotherboardId { get; set; }

        [Required]
        public string Ram { get; set; } = null!;

        public Guid HighestBidderId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
