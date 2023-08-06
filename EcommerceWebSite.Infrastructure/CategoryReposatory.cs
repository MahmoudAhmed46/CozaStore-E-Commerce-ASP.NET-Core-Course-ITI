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
	public class CategoryReposatory : Reposatory<Category, int>, ICategoryReposatory
	{
		public CategoryReposatory(SiteContext context) : base(context)
		{
		}
	}
}
