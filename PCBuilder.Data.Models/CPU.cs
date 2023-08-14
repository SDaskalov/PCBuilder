namespace PCBuilder.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static PCBuilder.Common.ValidationConstants.CpuConstants;

    public class CPU
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength()]
        public string ModelName { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int SocketId { get; set; }

        public Socket Socket { get; set; } = null!;

        [Required]
        public int VendorId { get; set; }

        public CpuVendor Vendor { get; set; } = null!;

        [Required]
        public bool IntegratedGraphics { get; set; }

        [Required]
        public int MaxWattage { get; set; }
    }
}