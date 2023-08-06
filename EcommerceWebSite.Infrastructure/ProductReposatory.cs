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
	public class ProductReposatory : Reposatory<Product, int>, IProductReposatory
	{
		public ProductReposatory(SiteContext context) : base(context)
		{

		}
	}
}
