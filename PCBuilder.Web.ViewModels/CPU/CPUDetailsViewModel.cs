namespace PCBuilder.Web.ViewModels.CPU
{
    using PCBuilder.Web.ViewModels.Sockets;
    using PCBuilder.Web.ViewModels.Vendor;
    using System.ComponentModel.DataAnnotations;
    using static PCBuilder.Common.ValidationConstants.CpuConstants;

    public class CPUDetailsViewModel
    {

        public CPUDetailsViewModel()
        {
            this.VendorCategories = new HashSet<CPUVendorCategoryFormModel>();
            this.SocketCategories = new HashSet<SocketCategoryFormModel>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(MaxNameLength)]
        public string ModelName { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }
        [Required]
        public int SocketId { get; set; }
        [Required]
        public int VendorId { get; set; }
        [Required]
        public bool IntegratedGraphics { get; set; }
        [Required]
        [Range(MinWatts, MaxWatts)]
        public int MaxWattage { get; set; }

        public string VendorName { get; set; } = null!;
        public string SocketName { get; set; } = null!;

        public IEnumerable<CPUVendorCategoryFormModel> VendorCategories { get; set; }

        public IEnumerable<SocketCategoryFormModel> SocketCategories { get; set; }

    }
}
