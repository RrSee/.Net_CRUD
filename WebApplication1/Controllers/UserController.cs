using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Index()
		{
			var users = _userService.GetAll();
			return View(users);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(User user)
		{
			if(ModelState.IsValid)
			{
				_userService.Add(user);
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var user = _userService.GetById(id);
			if(user == null)
			{
				return NotFound();
			}
			return View(user);
		}
		[HttpPost]
		public IActionResult Edit(User user)
		{
			if(ModelState.IsValid)
			{
				_userService.Update(user);
				return RedirectToAction("Index");
			}
			return View(user);
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var product = _userService.GetById(id);
			if(product == null)
			{
				return NotFound();
			}
			return View(product);
		}
		[HttpPost,ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			_userService.Delete(id);
			return RedirectToAction("Index");
		}

	}
}
