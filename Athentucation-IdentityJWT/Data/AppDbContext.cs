using Athentucation_IdentityJWT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Athentucation_IdentityJWT.Data
{
	public class AppDbContext : IdentityDbContext<AccountIdentity>
	{
		public DbSet<localUser> LocalUsers { get; set; }
		public DbSet<AccountIdentity> Users { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

	}


}
