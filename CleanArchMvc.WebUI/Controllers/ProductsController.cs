using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace CleanArchMvc.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;
        public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _environment = environment;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(productDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(productDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var productDTO = await _productService.GetById(id.Value);
            if (productDTO == null) return NotFound();

            ViewBag.CategoryId = new SelectList(await _categoryService.GetAll(), "Id", "Name", productDTO.CategoryId);

            return View(productDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productService.Update(productDto);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var productDto = await _productService.GetById(id.Value);
            if(productDto == null) return NotFound();

            return View(productDto);
        }

        [HttpPost(),ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) return NotFound();
            await _productService.Remove(id.Value);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var productDTO = await _productService.GetById(id.Value);
            if (productDTO == null) return NotFound();

            var wwwroot = _environment.WebRootPath;
            var image = Path.Combine(wwwroot,"images\\" +  productDTO.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;            

            return View(productDTO);
        }
    }
}
