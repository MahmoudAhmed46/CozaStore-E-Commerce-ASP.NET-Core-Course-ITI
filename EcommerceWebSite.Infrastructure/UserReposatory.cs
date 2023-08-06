using EcommerceWebSite.Application.Contracts;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Infrastructure
{
	public class UserReposatory : Reposatory<ApplicationUser, string>, IUserReposatory
	{
		SiteContext _Context;
		public UserReposatory(SiteContext context) : base(context)
		{
			_Context = context;
		}

		public   Task<ApplicationUser> CheckforUser(string pwd, string email)
		{
			ApplicationUser usr = _Context.Users.FirstOrDefault(p => p.Email == email/*&& p.Password==pwd*/);
			return Task.FromResult(usr);
		}
	}
}
