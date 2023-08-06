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
	public class ProductService : IProductService
	{
		private readonly IProductReposatory productsRepo;
		private readonly IMapper _mapper;

		public ProductService(IProductReposatory _productsRepo, IMapper mapper)
        {
			productsRepo = _productsRepo;
			_mapper = mapper;
		}
        public async Task<IQueryable<GetAllProductPaginationDTO>> GetAllProductPagination(int item, int Pagenumber,int catId)
		{
			var AllProducts =await productsRepo.GetAllAsync();
			//var productspagination;
			IQueryable<GetAllProductPaginationDTO> productspagination;
			if (catId > 0)
			{
				     productspagination = AllProducts.Where(p => p.CategoryId == catId && p.UnitInStock>0).Skip(item * (Pagenumber - 1)).Take(item).
					Select(p => new GetAllProductPaginationDTO
					{
						Id = p.Id,
						Name = p.Name,
						Description = p.Description,
						Price = p.Price,
						CategoryId = p.CategoryId,
						Images = p.Images.Select(i => i).ToList()
					});
			}
			else
			{
				productspagination = AllProducts.Where(p => p.CategoryId != null && p.UnitInStock > 0).Skip(item * (Pagenumber - 1)).Take(item).
				   Select(p => new GetAllProductPaginationDTO
				   {
					   Id = p.Id,
					   Name = p.Name,
					   Description = p.Description,
					   Price = p.Price,
					   CategoryId = p.CategoryId,
					   Images = p.Images.Select(i => i).ToList()
				   });
			}
			return productspagination;
		}
		public async Task<List<ProductDTO>> GetAllAsync()
		{
			var products = await productsRepo.GetAllAsync();
			return _mapper.Map<List<ProductDTO>>(products);
		}
		public async Task<ProductDTO> CreateAsync(CreateProductDTO createProductDTO)
		{
			if (createProductDTO.ProductDTO.UnitInStock > 0)
				createProductDTO.ProductDTO.Status = true;
			else
				createProductDTO.ProductDTO.Status = false;
			var product = _mapper.Map<Product>(createProductDTO.ProductDTO);
			var result = await productsRepo.CreateAsync(product);
			return _mapper.Map<ProductDTO>(result);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var product = await productsRepo.GetByIdAsync(id);
			var res = await productsRepo.DeleteAsync(product);
			await productsRepo.SaveChangesAsync();
			return res;
		}
		public async Task<ProductDTO> getByIdAsync(int id)
		{
			var product = await productsRepo.GetByIdAsync(id);
			return _mapper.Map<ProductDTO>(product);
		}
		public async Task<bool> updateAsync(CreateProductDTO productDTO)
		{
			var product = _mapper.Map<Product>(productDTO.ProductDTO);
			var res = await productsRepo.UpdateAsync(product);
			await productsRepo.SaveChangesAsync();
			return res;
		}

		public async Task<int> GetQuantity(int productId)
		{
			var product = await productsRepo.GetByIdAsync(productId);
			return product?.UnitInStock??0;
		}

		public async Task<bool> updateQuantity(int productId, int newQuantity)
		{
			var product = await productsRepo.GetByIdAsync(productId);
			product.UnitInStock -= newQuantity;
			bool res=false;
			if (product != null)
			{
				res = await productsRepo.UpdateAsync(product);
				await productsRepo.SaveChangesAsync();
			}
			
			return  (res) ? true : false;
		}
	}
}
