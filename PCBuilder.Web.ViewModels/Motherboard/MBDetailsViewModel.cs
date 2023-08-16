
namespace PCBuilder.Web.ViewModels.Motherboard
{
    using PCBuilder.Web.ViewModels.Sockets;
    using PCBuilder.Web.ViewModels.Vendor;
    using System.ComponentModel.DataAnnotations;
    using static PCBuilder.Common.ValidationConstants.MotherBoardConstants;
    public class MBDetailsViewModel
    {
        public MBDetailsViewModel()
        {
            VendorCategories = new HashSet<CPUVendorCategoryFormModel>();
            SocketCategories = new HashSet<SocketCategoryFormModel>();
        }
        public int Id { get; set; }

        [Required]
        [MinLength(MinNameLength)]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [Range(MinRamCapacity, MaxRamCapacity)]
        public int RamCapacity { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        public int SocketId { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        public IEnumerable<CPUVendorCategoryFormModel> VendorCategories { get; set; }

        public IEnumerable<SocketCategoryFormModel> SocketCategories { get; set; }

        public string SocketName { get; set; } = null!;

        public string VendorName { get; set; } = null!;

    }
}
