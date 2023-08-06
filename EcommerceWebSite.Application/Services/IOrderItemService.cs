using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
	public interface IOrderItemService
	{
		public Task<bool> CreateOrderItem(OrderItemDto orderItemDto);

	}
}
