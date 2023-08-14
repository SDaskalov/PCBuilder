
namespace PCBuilder.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static PCBuilder.Common.ValidationConstants.MotherBoardConstants;

    public class MotherBoard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int VendorId { get; set; }

        public CpuVendor Vendor { get; set; } = null!;

        [Required]
        public int SocketId { get; set; }

        public Socket Socket { get; set; } = null!;

        [Required]
        public int RamCapacity { get; set; }

    }
}
