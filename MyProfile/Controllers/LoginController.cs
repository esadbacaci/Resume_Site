using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MyProfile.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		//		[HttpPost]
		//		public IActionResult Index(Director p)
		//		{
		//			Context c = new Context();
		//			var adminuserinfo = c.Directors.FirstOrDefault(x => x.DirectorName == p.DirectorName && x.DirectorPassword == p.DirectorPassword);

		//			if (adminuserinfo != null)
		//			{
		//				return RedirectToAction("Index", "Category");
		//			}
		//			else
		//			{
		//				return RedirectToAction("Index");
		//			}

		//		}

		//	}
		//}
		public async Task<IActionResult> Index(Director p)
		{
			Context c = new Context();
			var datavalue = c.Directors.FirstOrDefault(x => x.DirectorName == p.DirectorName && x.DirectorPassword == p.DirectorPassword);
			if (datavalue != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,p.DirectorName)
				};
				var useridentity = new ClaimsIdentity(claims, "a");
				ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(principal);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				return View();
			}
		}
	}
}