using AutoMapper;
using EcommerceWebSite.Application.Services;
using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceWebSiteMVC.Controllers
{
	public class UserAccountController : Controller
	{

		IUserServices _userServices;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserAccountController(IUserServices userServices,
			ICityService cityService,IMapper mapper
			,UserManager<ApplicationUser> userManager
			,SignInManager<ApplicationUser> signInManager)
		{
			_userServices = userServices;
            _cityService = cityService;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> Login()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(UserLoginDTO userLogin)
		{
			if(ModelState.IsValid)
			{
			   var user=await _userManager.FindByNameAsync(userLogin.userName);				
				if (user != null)
				{
					var result=await _signInManager.PasswordSignInAsync(user,userLogin.Password,userLogin.RememberMe,false);
					if(result.Succeeded)
					   return RedirectToAction("Index", "Home");
				}
			}
			return View();
		}
		public async Task<IActionResult> Register()
		{
			UserRegisterDTO userDTO = new UserRegisterDTO();
			userDTO.Cities = await _cityService.GetCities();
            return View(userDTO);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(UserRegisterDTO userDto)
		{
			if (ModelState.IsValid)
			{
				var user = _mapper.Map<ApplicationUser>(userDto);
				IdentityResult result = await _userManager.CreateAsync(user,userDto.PasswordHash);
				
				if (result.Succeeded)
				{
					var id = await _userManager.GetUserIdAsync(user);
					var claims = new List<Claim>
						{
							new Claim(ClaimTypes.Name, user.UserName),
							new Claim(ClaimTypes.NameIdentifier,id)
						};
					await _signInManager.SignInWithClaimsAsync(user,false,claims);
					return RedirectToAction("login");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("",item.Description);
					}
				}
			}
            userDto.Cities = await _cityService.GetCities();
			return View(userDto);
		}
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
		}
	}
}
