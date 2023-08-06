using EcommerceWebSite.Application.Services;
using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace EcommerceWebSiteMVC.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService orderService;
		private readonly IOrderItemService orderItemService;
		private readonly IProductService productService;
	
		public OrderController(IOrderService _orderService,IOrderItemService _orderItemService, IProductService _productService)
        {
			orderService = _orderService;
			orderItemService = _orderItemService;
			productService = _productService;
		
		}
        public IActionResult Index()
		{
			return View();
		}
		async Task<bool> CheckUserCart()
		{
			List<userCartDTO> cartItems = new List<userCartDTO>();
			var userID = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name);
			string cookieValue;

			if (Request.Cookies.TryGetValue(userID.Value, out cookieValue))
			{
				cartItems = JsonConvert.DeserializeObject<List<userCartDTO>>(cookieValue);
			}
			foreach(var item in cartItems)
			{
				int quantity = await productService.GetQuantity(item.Id);
				if (quantity < item.Quantity)
				{
					return false;
				}
			}
			return true;
		}
		public async Task<IActionResult> CreateOrder(decimal totalPrice)
		{
			List<userCartDTO> cartItems = new List<userCartDTO>();
			var userID = User.Claims.FirstOrDefault(p => p.Type == ClaimTypes.Name);
			var UID = User.Claims.FirstOrDefault(u=>u.Type == ClaimTypes.NameIdentifier);
			var orderDto = new OrderDTO()
			{
				OrderDate = DateTime.Now,
				ArrivalDate = DateTime.Now.AddDays(3),
				Address = "sohag",  //User.Identity.Address
				TotalPrice = totalPrice,
				UserId = UID.Value //"3265a9de-b2fb-4dd9-a491-2eb47da5cf88"   //User.Identity.Name //User.Identity.
			};
			if (await CheckUserCart())
			{
				var orderResDto = await orderService.CreateOrderAsync(orderDto);
				string cookieValue;
				int quantity=0;
				if (Request.Cookies.TryGetValue(userID.Value, out cookieValue))
				{
					cartItems = JsonConvert.DeserializeObject<List<userCartDTO>>(cookieValue);
				}
				foreach (var itemOrder in cartItems)
				{
				  quantity = await productService.GetQuantity(itemOrder.Id);
					if (itemOrder.Quantity < quantity)
					{

						var itemDto = new OrderItemDto()
						{ OrderId = orderResDto.Id, Count = itemOrder.Quantity, ProductId = itemOrder.Id };
						bool res = await orderItemService.CreateOrderItem(itemDto);
						bool updated = await productService.updateQuantity(itemOrder.Id, itemOrder.Quantity);

					}
						
				}
				Response.Cookies.Delete(userID.Value);
				return Json(quantity);
			}
			return RedirectToAction("Index","Home");
		}
		


	}
}
