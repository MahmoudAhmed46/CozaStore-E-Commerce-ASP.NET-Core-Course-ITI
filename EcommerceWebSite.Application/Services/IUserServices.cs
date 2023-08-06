using EcommerceWebSite.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Application.Services
{
	public interface IUserServices
	{
		Task<UserRegisterDTO> Create(UserRegisterDTO userDTO);
		Task<bool> Update(UserRegisterDTO userDTO);
		Task<UserRegisterDTO> Login(string pwd, string email);
	}
}
