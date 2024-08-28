using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Pustok2.Business.Exceptions.CommonExceptions;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.Utilities.Extensions;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;
using Pustok2.Core.Repositories;

namespace Pustok2.Business.Services.Implementations
{
	public class SlideService : ISlideService
	{
		private readonly ISlideRepository _repository;
		private readonly IWebHostEnvironment _env;

		public SlideService(ISlideRepository repository, IWebHostEnvironment env)
		{
			_repository = repository;
			_env = env;
		}
		public async Task CreateAsync(CreateSlideVM slideVM)
		{
			string imageUrl = slideVM.Photo != null ? slideVM.Photo.CreateFileAsync(_env.WebRootPath, "uploads/slides") : string.Empty;

			Slide slide = new Slide
			{
				Title = slideVM.Title,
				Subtitle = slideVM.Subtitle,
				ImageUrl = imageUrl,
				Createdtime = DateTime.Now,
				Updatedtime = DateTime.Now,
				IsDeleted = false
			};

			await _repository.CreateAsync(slide);
			await _repository.CommitAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null)
			{
				throw new EntityNotFoundException("Slide not found.");
			}
			_repository.Delete(entity);
			await _repository.CommitAsync();
		}

		public async Task<ICollection<Slide>> GetAllAsync()
		{
			return await _repository.GetAll(null).ToListAsync();
		}

		public async Task<Slide> GetByIdAsync(int? id)
		{
			if (id == null)
			{
				throw new IdIsNotValidException("Id not valid");
			}

			var entity = await _repository.GetByIdAsync(id);
			if (entity == null)
			{
				throw new EntityNotFoundException("Slide not found.");
			}

			return entity;
		}

		public async Task UpdateAsync(int? id, UpdateSlideVM slideVM)
		{
			if (id == null)
			{
				throw new IdIsNotValidException("Id not valid");
			}

			var entity = await _repository.GetByIdAsync(id.Value);
			if (entity == null)
			{
				throw new EntityNotFoundException("Slide not found.");
			}

			entity.Title = slideVM.Title;
			entity.Subtitle = slideVM.Subtitle;

			if (slideVM.Photo != null)
			{
				string imageUrl = slideVM.Photo.CreateFileAsync(_env.WebRootPath, "uploads/slides");
				entity.ImageUrl = imageUrl;
			}

			entity.Updatedtime = DateTime.Now;

			await _repository.CommitAsync();
		}

	}
}
