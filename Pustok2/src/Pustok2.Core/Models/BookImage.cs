namespace Pustok2.Core.Models
{
	public class BookImage : BaseEntity
	{
		public string ImageUrl { get; set; }
		public int BookId { get; set; }
		public bool? IsPrimary { get; set; }
		public Book Book { get; set; }
	}
}
