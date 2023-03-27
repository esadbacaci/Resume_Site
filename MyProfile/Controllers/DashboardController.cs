using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyProfile.Controllers
{
	public class DashboardController : Controller
	{
		[Authorize]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
