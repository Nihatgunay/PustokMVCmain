namespace Pustok2.Core.Models
{
	public class Book : BaseEntity
	{
		public int AuthorId { get; set; }
		public int GenreId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public double CostPrice { get; set; }
		public double SalePrice { get; set; }
		public int SalePercent { get; set; }
		public bool IsAvailable { get; set; }
		public int StockCount { get; set; }
		public string Code { get; set; }

		public Author Author { get; set; }
		public Genre Genre { get; set; }
		public List<BookImage> BookImages { get; set; }
	}
}
