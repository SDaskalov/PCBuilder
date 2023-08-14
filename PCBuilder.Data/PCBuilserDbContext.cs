namespace PCBuilder.Data
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using PCBuilder.Data.Models;

	public class PCBuilserDbContext : IdentityDbContext<ApplicationUser , IdentityRole<Guid>, Guid>
	{
		public PCBuilserDbContext(DbContextOptions<PCBuilserDbContext> options)
			: base(options)
		{

		}
	}
}