using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pustok2.Core.Models;

namespace Pustok2.Data.Configurations
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.Property(x => x.Title)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Description)
				.IsRequired()
				.HasMaxLength(500);

			builder.Property(x => x.Code)
				.IsRequired()
				.HasMaxLength(10);

			builder.Property(x => x.SalePrice)
				.IsRequired();

			builder.Property(x => x.CostPrice)
				.IsRequired();

			builder.HasOne(x => x.Author).WithMany(x => x.Books)
				.HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);

			builder.HasMany(x => x.BookImages).WithOne(x => x.Book)
				.HasForeignKey(x => x.BookId).OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(x => x.Genre).WithMany(x => x.Books)
				.HasForeignKey(x => x.GenreId).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
