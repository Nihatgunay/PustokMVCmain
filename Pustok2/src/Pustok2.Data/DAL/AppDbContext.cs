using Microsoft.EntityFrameworkCore;
using Pustok2.Core.Models;
using Pustok2.Data.Configurations;

namespace Pustok2.Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookImage> BookImages { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);

			base.OnModelCreating(modelBuilder);
		}
	}
}
