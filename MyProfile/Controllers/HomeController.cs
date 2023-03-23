using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using MyProfile.Models;
using System.Diagnostics;

namespace MyProfile.Controllers
{
	public class HomeController : Controller
	{
		CategoryManager cm = new CategoryManager(new EfCategoryRepository());
		ProjectManager pm = new ProjectManager(new EfProjectRepository());
		Context c = new Context();
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var project = pm.GetList();
			var categories = cm.GetList();
			var model2 = new EntityLayer.Concrete.Category();
			var viewModel = new MyViewModel
			{
				Projects = project,
				Category = model2,
				Categories = categories
			};

			return View(viewModel);

			
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}