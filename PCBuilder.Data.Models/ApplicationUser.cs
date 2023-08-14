using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Data.Models
{
	public class ApplicationUser : IdentityUser<Guid>
	{
        public ApplicationUser()
        {
            this.Configurations= new List<PCConfiguration>();

		}

        public virtual ICollection<PCConfiguration> Configurations { get; set; }

    }
}
