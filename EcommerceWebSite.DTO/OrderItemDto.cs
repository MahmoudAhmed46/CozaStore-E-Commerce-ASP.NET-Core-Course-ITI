using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.DTO
{
	public class OrderItemDto
	{
		public int OrderId { get; set; }
		public int Count { get; set; }
		public int ProductId { get; set; }
	}
}
