using System.ComponentModel.DataAnnotations;

namespace PCBuilder.Web.ViewModels.PCConfiguration
{
    public class PCBuildViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;


        public string HighestBid { get; set; } = null!;

        [Required]
        public string Cpu { get; set; } = null!;

        [Required]
        public string Gpu { get; set; } = null!;

        [Required]
        public string Motherboard { get; set; } = null!;

        [Required]
        public string Ram { get; set; } = null!;
    }
}
