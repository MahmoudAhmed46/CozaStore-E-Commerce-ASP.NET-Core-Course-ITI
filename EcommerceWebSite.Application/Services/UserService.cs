using AutoMapper;
using EcommerceWebSite.Application.Contracts;
using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
	public class UserService:IUserServices
	{
		IUserReposatory _UsrRepo;
		IMapper Mapper;
		public UserService(IUserReposatory usrRepo, IMapper mapper)
		{
			_UsrRepo = usrRepo;
			Mapper = mapper;
		}

		public async Task<UserRegisterDTO> Create(UserRegisterDTO userDTO)
		{
			ApplicationUser user=Mapper.Map<ApplicationUser>(userDTO);
			ApplicationUser usr=await _UsrRepo.CreateAsync(user);
			await _UsrRepo.SaveChangesAsync();
			return Mapper.Map<UserRegisterDTO>(usr);
		}

		public async Task<UserRegisterDTO> Login(string pwd, string email)
		{
			ApplicationUser user = await _UsrRepo.CheckforUser(pwd, email);
			return Mapper.Map<UserRegisterDTO>(user);
		}

		public async Task<bool> Update(UserRegisterDTO userDTO)
		{
			ApplicationUser user = Mapper.Map<ApplicationUser>(userDTO);
			bool res = await _UsrRepo.UpdateAsync(user);
			//await _UsrRepo.SaveChangesAsync();
			return res;
		}
	}
}
