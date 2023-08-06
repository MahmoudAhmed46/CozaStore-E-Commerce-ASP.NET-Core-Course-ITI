using AutoMapper;
using EcommerceWebSite.Application.Contracts;
using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
	public class CategoryService : IcategoryServices
	{
		ICategoryReposatory _Repo;
		private readonly IMapper mapper;
		public CategoryService(ICategoryReposatory repo, IMapper mapper)
		{
			_Repo = repo;
			this.mapper = mapper;
		}

		public async Task<List<CategoryDTO>> GetAllCategory()
		{
			return (await _Repo.GetAllAsync()).Select(p=>new CategoryDTO {Id=p.Id,Name=p.Name }).ToList();
		}

		public async Task<CategoryDTO> CreateAsync(CategoryDTO categoryDTO)
		{

			var category = mapper.Map<Category>(categoryDTO);
			var cat = await _Repo.CreateAsync(category);
			await _Repo.SaveChangesAsync();
			return mapper.Map<CategoryDTO>(category);
		}
		public async Task<CategoryDTO> GetByIdAsync(int ID)
		{
			var cat = await _Repo.GetByIdAsync(ID);
			return new CategoryDTO { Id = cat.Id, Name = cat.Name, Description = cat.Description };


		}
		public async Task<bool> updateAsync(CategoryDTO categoryDTO)
		{
			var category = mapper.Map<Category>(categoryDTO);
			var cat = await _Repo.UpdateAsync(category);
			await _Repo.SaveChangesAsync();
			return cat;
		}
		public async Task<bool> DeleteAsync(int id)
		{
			var category = await _Repo.GetByIdAsync(id);
			var res = await _Repo.DeleteAsync(category);
			await _Repo.SaveChangesAsync();
			return res;

		}

	}
}
