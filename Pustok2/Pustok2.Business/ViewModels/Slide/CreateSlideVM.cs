using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Pustok2.Business.ViewModels
{
	public class CreateSlideVM
	{
		public string Title { get; set; }
		public string Subtitle { get; set; }
		[Required]
		public IFormFile Photo { get; set; }
	}
}
