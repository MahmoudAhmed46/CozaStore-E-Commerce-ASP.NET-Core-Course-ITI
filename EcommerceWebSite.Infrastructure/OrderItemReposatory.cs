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
	public class OrderItemReposatory : Reposatory<OrderItem, int>, IOrderItemReposatory
	{
		public OrderItemReposatory(SiteContext context) : base(context)
		{
		}
	}
}
