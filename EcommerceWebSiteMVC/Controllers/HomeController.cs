using EcommerceWebSite.Application.Services;
using EcommerceWebSite.DTO;
using EcommerceWebSiteMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EcommerceWebSiteMVC.Controllers
{
    public class HomeController : Controller
    {
		private readonly IcategoryServices _Category;
		private readonly IProductService productSrevice;

		public HomeController(IcategoryServices icategory,IProductService _productSrevice)
        {
            _Category = icategory;
            productSrevice = _productSrevice;
		}

        public async Task<IActionResult> Index()
        {
			CategoryProductsDTO categoryProductsDTO = new CategoryProductsDTO();
			categoryProductsDTO.Products = await productSrevice.GetAllProductPagination(4, 1,0);
			categoryProductsDTO._categories = await _Category.GetAllCategory();
			return View(categoryProductsDTO);
        }
        public async Task<IActionResult> LoadMore(int page,int catId)
		{
			return Json(await productSrevice.GetAllProductPagination(4, page, catId));
		}


	}
}