using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace EcommerceWebSiteMVC.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public  IActionResult ProductDetails(string product)
		{
			var product1 = JsonConvert.DeserializeObject<GetAllProductPaginationDTO>(product);
			//var product1 = JsonSerializer.Deserialize<GetAllProductPaginationDTO>(product);
			return View(product1);
		}
	}
}
