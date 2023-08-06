using EcommerceWebSite.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = EcommerceWebSite.Domain.Image;

namespace EcommerceWebSite.DTO
{
	public class GetAllProductPaginationDTO
	{
		public int Id { get; set; }
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Name Length Must Be Between 3 to 50 char")]
		public String Name { get; set; }
		public decimal Price { get; set; }

		public string Description { get; set; }
		public int CategoryId { get; set; }

		//public List<string> ImageUrls { get; set; }
		public List<Image> Images { get; set; }

	}
}
