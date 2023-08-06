using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.DTO
{
	public class OrderDTO
	{
		public int Id { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime ArrivalDate { get; set; }

		[StringLength(150, MinimumLength = 5, ErrorMessage = "Name Length Must Be Between 3 to 50 char")]
		public string Address { get; set; }
		public decimal TotalPrice { get; set; }
		public string UserId { get; set; }

	}
}
