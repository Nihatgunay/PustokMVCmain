using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Pustok2.Business.ViewModels
{
	public class CreateBookVM
	{
		public int AuthorId { get; set; }
		public int GenreId { get; set; }
		[Required]
		[StringLength(100)]
		public string Title { get; set; }
		[Required]
		[StringLength(500)]
		public string Description { get; set; }
		public double CostPrice { get; set; }
		public double SalePrice { get; set; }
		public int SalePercent { get; set; }
		public bool IsAvailable { get; set; }
		public int StockCount { get; set; }
		[Required]
		[StringLength(10)]
		public string Code { get; set; }

		public IFormFile PosterImage { get; set; }
		public IFormFile HoverImage { get; set; }
		public List<IFormFile>? Images { get; set; }
	}
}
