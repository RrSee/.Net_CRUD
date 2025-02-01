using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
		{
			var products = _productService.GetAll();
			return View(products);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product product)
		{
			if(ModelState.IsValid)
			{
				_productService.Add(product);
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var product = _productService.GetById(id);
			if(product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		[HttpPost]
		public IActionResult Edit(Product product)
		{
			if(ModelState.IsValid)
			{
				_productService.Update(product);
				return RedirectToAction("index");
			}
			return View(product);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var product = _productService.GetById(id);
			if( product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			_productService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
