namespace PCBuilder.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GraphicsCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ModelName { get; set; } = null!;

        [Required]
        public int MaxWattage { get; set; }

        [Required]
        [MaxLength(PCBuilder.Common.ValidationConstants.CaseConstants.MaxCaseImageLength)]
        public string ImageURL { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Guid BuilderId { get; set; }

        public bool IsDeleted { get; set; }

    }
}
