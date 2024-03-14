using Athentucation_IdentityJWT.Models;
using Microsoft.EntityFrameworkCore;

namespace Athentucation_IdentityJWT.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<localUser> LocalUsers { get; set; }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

	}


}
