using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;

namespace Pustok2.Business.Services.Interfaces
{
	public interface ISlideService
	{
		Task CreateAsync(CreateSlideVM slideVM);
		Task UpdateAsync(int? id, UpdateSlideVM slideVM);
		Task<Slide> GetByIdAsync(int? id);
		Task DeleteAsync(int id);
		Task<ICollection<Slide>> GetAllAsync();
	}
}
