using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
	public interface IProductService
	{
		public Task<IQueryable<GetAllProductPaginationDTO>> GetAllProductPagination(int item,int Pagenumber,int catId);
		Task<List<ProductDTO>> GetAllAsync();
		Task<ProductDTO> CreateAsync(CreateProductDTO createProductDTO);
		Task<bool> DeleteAsync(int id);
		Task<ProductDTO> getByIdAsync(int id);
		Task<bool> updateAsync(CreateProductDTO productDTO);
		Task<int> GetQuantity(int productId);
		Task<bool> updateQuantity(int productId, int newQuantity);
	}
}
