using EcommerceWebSite.Application.Contracts;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Infrastructure
{
    public class ImageRepository : Reposatory<Image, int>,IImageReposatory
    {
        SiteContext _Context;
        public ImageRepository(SiteContext context) : base(context)
        {
            _Context = context; 
        }

        public  Task<List<Image>> GetImagesByPrdId(int id)
        {
          return Task.FromResult
                (_Context.Images.Where(i => i.ProductID == id).ToList());
        }
    }
}
