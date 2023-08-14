namespace PCBuilder.Data.Models
{

using System.ComponentModel.DataAnnotations;
using static PCBuilder.Common.ValidationConstants.Socket;

    public class Socket
    {
     
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

   

    }
}
