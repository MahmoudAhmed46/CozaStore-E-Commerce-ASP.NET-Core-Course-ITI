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
	public class OrderService : IOrderService
	{
		private readonly IOrderReposatory OrderRepo;
        public OrderService(IOrderReposatory _OrderRepo)
        {
			OrderRepo = _OrderRepo;

		}

		public async Task<OrderDTO> CreateOrderAsync(OrderDTO orderDto)
		{
			Order order = new Order();
			order.OrderDate = orderDto.OrderDate;
			order.ArrivalDate = orderDto.ArrivalDate;
			order.Address = orderDto.Address;
			order.TotalPrice = orderDto.TotalPrice;
			order.UserId = orderDto.UserId;
			var orderCreated = await OrderRepo.CreateAsync(order);
			//await OrderRepo.SaveChangesAsync();

			return new OrderDTO()
			{
				Id = orderCreated.Id,
				OrderDate = orderCreated.OrderDate,
				ArrivalDate = orderCreated.ArrivalDate,
				TotalPrice = orderCreated.TotalPrice,
				Address = orderCreated.Address,
				UserId = orderCreated.UserId
			};
		}
	}
}
