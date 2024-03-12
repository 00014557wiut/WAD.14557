using Microsoft.EntityFrameworkCore;
using WAD.CW1._14557.Models;

namespace WAD.CW1._14557.AppData
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
		}

		public DbSet<Issue> Issues { get; set; }
		public DbSet<Comment> Comments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// If you have any fluent API configurations, they would go here.
			// For example, to configure a one-to-many relationship between Issue and Comment:
			modelBuilder.Entity<Issue>()
				.HasMany(i => i.Comments)
				.WithOne(c => c.Issue)
				.HasForeignKey(c => c.IssueId);
		}
	}
}
