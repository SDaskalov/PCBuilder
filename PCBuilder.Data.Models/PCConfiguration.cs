
namespace PCBuilder.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PCConfiguration
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public int MotherBoardId { get; set; }

        public MotherBoard MotherBoard { get; set; } = null!;

        [Required]
        public int CPUId { get; set; }

        public CPU CPU { get; set; } = null!;

        public int? GraphicsCardId { get; set; }

        public GraphicsCard? GraphicsCard { get; set; }

        [Required]
        public int CaseId { get; set; }

        public ComputerCase ComputerCase { get; set; } = null!;

        [Required]
        public int TotalSystemWattage { get; set; }

        public Guid BuilderId { get; set; }

        public virtual Builder Builder { get; set; } = null!;

        public decimal HighestBid { get; set; }

        public Guid? BidderId { get; set; }

        public virtual ApplicationUser? Bidder { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsSold { get; set; }

    }
}
