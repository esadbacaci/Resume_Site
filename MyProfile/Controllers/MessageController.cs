using Microsoft.AspNetCore.Mvc;

namespace MyProfile.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
