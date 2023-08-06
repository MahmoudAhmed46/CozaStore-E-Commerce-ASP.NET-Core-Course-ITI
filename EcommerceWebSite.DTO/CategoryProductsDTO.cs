using EcommerceWebSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.DTO
{
	public class CategoryProductsDTO
	{
		public List<CategoryDTO> _categories { get; set; }
		public IQueryable<GetAllProductPaginationDTO> Products { get; set; }
	}
}
