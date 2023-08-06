using EcommerceWebSite.Application.Contracts;
using EcommerceWebSite.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebSiteMVC.Controllers
{
	public class CategoryController : Controller
	{
		IcategoryServices _Category;
		public CategoryController(IcategoryServices category)
		{
			_Category = category;
		}

		public IActionResult Index()
		{
			return View();
			//return View("Index","Home",_Category.GetAllCategory());
		}
	}
}
