using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text.Json;
namespace EcommerceWebSiteMVC.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult ShoppingCart() 
		{
            List<userCartDTO> cartItems = new List<userCartDTO>();
			var userID = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name);


			string cookieValue;

            if (Request.Cookies.TryGetValue(userID.Value, out cookieValue))
            {
                cartItems = JsonConvert.DeserializeObject<List<userCartDTO>>(cookieValue);
            }
			return View(cartItems);
        }

		[HttpPost]
		public IActionResult AddToCart(string product,int quantity)
		{
			
			List<userCartDTO> cartItems = new List<userCartDTO>();
			var product1 = JsonConvert.DeserializeObject<GetAllProductPaginationDTO>(product);
			CookieOptions options = new CookieOptions();
			string cookieValue;
			var userID = User.Claims.FirstOrDefault(p=>p.Type == ClaimTypes.Name);

			if (Request.Cookies.TryGetValue(userID.Value, out cookieValue))
			{
				cartItems = JsonConvert.DeserializeObject<List<userCartDTO>>(cookieValue);
			}
			userCartDTO newItem;
			var found = cartItems.FirstOrDefault(p => p.Id == product1.Id);
			if(found != null)
			{
				cartItems.Remove(found);
				found.Quantity += quantity;
				cartItems.Add(found);
			}
			else 
			{
			     newItem = new userCartDTO
				{
					Id = product1.Id,
					Name = product1.Name,
					Price = product1.Price,
					Image = product1.Images[0],
					Quantity = quantity
				};
				cartItems.Add(newItem);

			}

			string res = JsonConvert.SerializeObject(cartItems);
			Response.Cookies.Append(userID.Value,res);
			return Json(cartItems.Count);
		}
		[HttpPost]
		public IActionResult Delete(int Id)
		{
			List<userCartDTO> cartItems = new List<userCartDTO>();
			var userID = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name);


			string cookieValue;
			if (Request.Cookies.TryGetValue(userID.Value, out cookieValue))
			{
				cartItems = JsonConvert.DeserializeObject<List<userCartDTO>>(cookieValue);
			}
			var found = cartItems.FirstOrDefault(p => p.Id == Id);
			if(found != null)
			{
				var removed = cartItems.Remove(found);
			}
			string res = JsonConvert.SerializeObject(cartItems);
			Response.Cookies.Delete(userID.Value);
			Response.Cookies.Append(userID.Value, res);
			return RedirectToAction("ShoppingCart");
		}
		public IActionResult Update(int Id,int quantity)
		{
			List<userCartDTO> cartItems = new List<userCartDTO>();
			var userID = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name);


			string cookieValue;
			if (Request.Cookies.TryGetValue(userID.Value, out cookieValue))
			{
				cartItems = JsonConvert.DeserializeObject<List<userCartDTO>>(cookieValue);
			}
			var userCart = cartItems.FirstOrDefault(p => p.Id == Id);
			int idx = cartItems.IndexOf(userCart);
			if (idx != -1)
			{
				cartItems[idx].Quantity= quantity;
			}
			string res = JsonConvert.SerializeObject(cartItems);
			Response.Cookies.Delete(userID.Value);
			Response.Cookies.Append(userID.Value, res);
			return Json(cartItems);
		}
		public IActionResult GetCookieItemCount()
		{
			List<userCartDTO> cartItems = new List<userCartDTO>();
			var userID = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name);


			string cookieValue;
			if (Request.Cookies.TryGetValue(userID.Value, out cookieValue))
			{
				cartItems = JsonConvert.DeserializeObject<List<userCartDTO>>(cookieValue);
			}
			return Json(cartItems.Count);
		}


	}
}
