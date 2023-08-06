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
	public class OrderItemService : IOrderItemService
	{
		private readonly IOrderItemReposatory orderItemRepo;

		public OrderItemService(IOrderItemReposatory _orderItemRepo)
        {
			orderItemRepo = _orderItemRepo;

		}
        public async Task<bool> CreateOrderItem(OrderItemDto orderItemDto)
		{
			OrderItem orderItem = new OrderItem();
			orderItem.OrderId = orderItemDto.OrderId;
			orderItem.ProductId = orderItemDto.ProductId;
			orderItem.Count = orderItemDto.Count;
			var orderItemCreated =await orderItemRepo.CreateAsync(orderItem);
			//await orderItemRepo.SaveChangesAsync();
			return ( orderItemCreated!= null ) ? true : false;
		}
	}
}
