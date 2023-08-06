using EcommerceWebSite.Application.Contracts;
using EcommerceWebSite.Application.Services;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain;
using EcommerceWebSite.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebSiteMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<SiteContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			});
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
			{
				option.Password.RequireUppercase = false;
			}).AddEntityFrameworkStores<SiteContext>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
			builder.Services.AddScoped<IcategoryServices, CategoryService>();
            builder.Services.AddScoped<ICategoryReposatory, CategoryReposatory>();
            builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<IProductReposatory, ProductReposatory>();
			builder.Services.AddScoped<IUserReposatory, UserReposatory>();
			builder.Services.AddScoped<IUserServices, UserService>();
			builder.Services.AddScoped<ICityReposatory, CityRepository>();
			builder.Services.AddScoped<ICityService, CityService>();
			builder.Services.AddScoped<IImageServices, ImageServices>();
			builder.Services.AddScoped<IImageReposatory, ImageRepository>();
			builder.Services.AddScoped<IOrderReposatory, OrderReposatory>();
            builder.Services.AddScoped<IOrderItemReposatory, OrderItemReposatory>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderItemService, OrderItemService>();

			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}