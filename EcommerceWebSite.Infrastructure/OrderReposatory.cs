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
	public class OrderReposatory : Reposatory<Order, int>, IOrderReposatory
	{
		public OrderReposatory(SiteContext context) : base(context)
		{
		}
	}
}
