namespace PCBuilder.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {


        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.Configurations = new List<PCConfiguration>();

        }

        public virtual ICollection<PCConfiguration> Configurations { get; set; }

    }
}
