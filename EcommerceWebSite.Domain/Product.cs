using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name Length Must Be Between 3 to 50 char")]
        public String Name { get; set; }
        public decimal Price { get; set; }
        public int UnitInStock { get; set; }
        public bool Status { get; set; }
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Name Length Must Be Between 10 to 200 char")]
        public string Description { get; set; }
        public virtual ICollection<Image> Images { get; set; } =
            new HashSet<Image>();
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } =
            new HashSet<OrderItem>();
    }
}
