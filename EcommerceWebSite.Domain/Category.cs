using System.ComponentModel.DataAnnotations;

namespace EcommerceWebSite.Domain
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(50,MinimumLength = 3,ErrorMessage = "Name Length Must Be Between 3 to 50 char")]
        public string Name { get; set; }
        [StringLength(200,MinimumLength =10, ErrorMessage = "Name Length Must Be Between 10 to 200 char")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; } =
            new HashSet<Product>();
        public virtual ICollection<Category>? Categories { get; set; } =
            new HashSet<Category>();
        public virtual Category? category { get; set; }
    }
}