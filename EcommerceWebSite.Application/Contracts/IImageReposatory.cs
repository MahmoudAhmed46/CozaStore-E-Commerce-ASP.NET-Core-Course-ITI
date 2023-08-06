using EcommerceWebSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Contracts
{
    public interface IImageReposatory:IReposatory<Image,int>
    {
		public Task<List<Image>> GetImagesByPrdId(int id);
	}
}
