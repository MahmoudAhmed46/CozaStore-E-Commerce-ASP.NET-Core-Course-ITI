using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.DTO
{
    public class CreateProductDTO
    {
        public ProductDTO? ProductDTO { get; set; }
        public List<CategoryDTO>? Categories { get; set; }
        public List<ImageDTO>? images { get; set; }
    }
}
