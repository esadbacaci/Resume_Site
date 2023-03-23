using Microsoft.AspNetCore.Mvc;

namespace MyProfile.Controllers.Admin
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
