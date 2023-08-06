using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
	public interface IOrderService
	{
		public Task<OrderDTO> CreateOrderAsync(OrderDTO orderDto);

	}
}
