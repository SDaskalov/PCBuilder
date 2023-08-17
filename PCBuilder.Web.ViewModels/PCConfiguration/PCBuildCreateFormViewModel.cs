
namespace PCBuilder.Web.ViewModels.PCConfiguration
{
    using System.ComponentModel.DataAnnotations;
    public class PCBuildCreateFormViewModel
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        public int MotherboardId { get; set; }

    }
}
