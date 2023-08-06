using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
	public interface IcategoryServices
	{
		Task<List<CategoryDTO>> GetAllCategory();
		Task<CategoryDTO> CreateAsync(CategoryDTO category);
		Task<CategoryDTO> GetByIdAsync(int ID);
		Task<bool> updateAsync(CategoryDTO category);
		Task<bool> DeleteAsync(int id);
	}
}
