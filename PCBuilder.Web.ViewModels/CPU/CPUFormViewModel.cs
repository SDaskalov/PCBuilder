﻿namespace PCBuilder.Web.ViewModels.CPU
{
    using PCBuilder.Web.ViewModels.Sockets;
    using PCBuilder.Web.ViewModels.Vendor;
    using System.ComponentModel.DataAnnotations;
    using static PCBuilder.Common.ValidationConstants.CpuConstants;

    public class CPUFormViewModel
    {

        public CPUFormViewModel()
        {
            this.VendorCategories = new HashSet<CPUVendorCategoryFormModel>();
            this.SocketCategories = new HashSet<SocketCategoryFormModel>();
        }
        [Required]
        [MaxLength(MaxNameLength)]
        public string ModelName { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public int SocketId { get; set; }

        public int VendorId { get; set; }
        [Required]
        public bool IntegratedGraphics { get; set; }
        [Required]
        public int MaxWattage { get; set; }

        public IEnumerable<CPUVendorCategoryFormModel> VendorCategories { get; set; }

        public IEnumerable<SocketCategoryFormModel> SocketCategories { get; set; }

    }
}
