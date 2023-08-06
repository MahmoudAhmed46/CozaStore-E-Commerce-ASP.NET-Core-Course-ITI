using EcommerceWebSite.Application.Services;
using EcommerceWebSite.Domain;
using EcommerceWebSite.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWebSiteMVC.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IcategoryServices _icategoryServices;
		private readonly IProductService _proudctServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IImageServices _imageServices;

        public AdminController(IcategoryServices icategoryServices,
			 IProductService proudctServices,IWebHostEnvironment webHostEnvironment, IImageServices imageServices)
        {
            _icategoryServices = icategoryServices;
			_proudctServices = proudctServices;
            _webHostEnvironment = webHostEnvironment;
            _imageServices = imageServices;

        }
        public async Task<IActionResult> Category()
        {
            List<CategoryDTO> categories= await _icategoryServices.GetAllCategory();
            return View(categories);
        }
		public async Task<IActionResult> Product()
		{
			List<ProductDTO> products = await _proudctServices.GetAllAsync();
			return View(products);
		}
		public async Task<IActionResult> AddProduct()
		{
            List<CategoryDTO> categories = await _icategoryServices.GetAllCategory();
			CreateProductDTO createProduct = new CreateProductDTO();
			createProduct.Categories = categories;
            return View(createProduct);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(CreateProductDTO createProductDTO,
                                                  IFormFile image)
        {
            if(ModelState.IsValid)
            {
               
                    string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string filname = new Guid().ToString() + "_" + image.FileName;
                    string fullPath = Path.Combine(uploadPath, filname);

                    using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
    
                var result= await _proudctServices.CreateAsync(createProductDTO);
                await _imageServices.CreateAsync(filname , result.Id);

                if (result != null)

                   return RedirectToAction("Product");
            }
            List<CategoryDTO> categories = await _icategoryServices.GetAllCategory();
            createProductDTO.Categories = categories;
            return View(createProductDTO);
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var productModel=await _proudctServices.getByIdAsync(id);
            CreateProductDTO productDTO = new CreateProductDTO();
			List<CategoryDTO> categories = await _icategoryServices.GetAllCategory();
            productDTO.images = await _imageServices.ProductImages(id);

            productDTO.Categories = categories;
            productDTO.ProductDTO = productModel;
			return View(productDTO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(CreateProductDTO createProductDTO)
		{
            if (ModelState.IsValid)
            {


               var result= await _proudctServices.updateAsync(createProductDTO);
                if (result)
                    return RedirectToAction("Product");
            }

            List<CategoryDTO> categories = await _icategoryServices.GetAllCategory();
            createProductDTO.Categories = categories;
            return View();
		}
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _proudctServices.DeleteAsync(id);
            return RedirectToAction("Product");
        }
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                CategoryDTO cat = await _icategoryServices.CreateAsync(categoryDTO);
                return Redirect("Category");
            }
            return View(categoryDTO);
        }
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _icategoryServices.GetByIdAsync(id);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var res = await _icategoryServices.updateAsync(categoryDTO);
                return RedirectToAction("category");
            }
            return View(categoryDTO);
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _icategoryServices.GetByIdAsync(id);
            var result = await _icategoryServices.DeleteAsync(id);
            return RedirectToAction("category");
        }

    }
}
