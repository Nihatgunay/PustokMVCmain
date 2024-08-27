using Microsoft.AspNetCore.Http;

namespace Pustok2.Business.ViewModels
{
	public class UpdateSlideVM
	{
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string ImageUrl { get; set; }

		public IFormFile? Photo { get; set; }
	}
}
