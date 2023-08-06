using AutoMapper;
using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
	public class AutoMapperProfile:Profile
	{
		public AutoMapperProfile() 
		{
			CreateMap<ApplicationUser, UserRegisterDTO>().ReverseMap();
			CreateMap<City, CitiesListDTO>().ReverseMap();
		}
	}
}
