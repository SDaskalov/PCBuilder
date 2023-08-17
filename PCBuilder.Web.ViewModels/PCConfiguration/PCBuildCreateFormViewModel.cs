
namespace PCBuilder.Web.ViewModels.PCConfiguration
{
    using PCBuilder.Web.ViewModels.ComputerCase;
    using PCBuilder.Web.ViewModels.CPU;
    using PCBuilder.Web.ViewModels.GPU;
    using PCBuilder.Web.ViewModels.Motherboard;
    using PCBuilder.Web.ViewModels.Vendor;
    using System.ComponentModel.DataAnnotations;
    public class PCBuildCreateFormViewModel
    {
        public PCBuildCreateFormViewModel()
        {
            this.CpuCategories = new HashSet<CPUDetailsViewModel>();
            this.GPUCategories = new HashSet<GPUFormViewModel>();
            this.CaseCategories = new HashSet<ComputerCaseFormViewModel>();
            this.MotherboardCategories = new HashSet<MBFormViewModel>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public int MotherboardId { get; set; }

        [Required]
        public int CPUId { get; set; }

        public Guid BuilderId { get; set; }

        [Required]
        [Range(1,10000)]
        public decimal InitialRequestedBid { get; set; }
        [Required]
        public int ComputerCaseId { get; set; }

        public int GPUId { get; set; }

        public int GpuPower { get; set; }
        
        public int CPUPower { get; set; }
             


        public IEnumerable<GPUFormViewModel> GPUCategories { get; set; }

        public IEnumerable<CPUDetailsViewModel> CpuCategories { get; set; }

        public IEnumerable<ComputerCaseFormViewModel> CaseCategories { get; set; }

        public IEnumerable<MBFormViewModel> MotherboardCategories { get; set; }

    }
}
