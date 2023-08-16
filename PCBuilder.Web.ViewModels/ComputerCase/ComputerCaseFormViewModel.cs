namespace PCBuilder.Web.ViewModels.ComputerCase
{
    using System.ComponentModel.DataAnnotations;
    using static PCBuilder.Common.ValidationConstants.CaseConstants;
    public class ComputerCaseFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string ModelName { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [MaxLength(MaxCaseImageLength)]
        public string ImageUrl { get; set; } = null!;

        public Guid BuilderId { get; set; }
    }
}