using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Reflection.Metadata;

namespace MyProfile.Controllers
{
  [Authorize]  
    public class CategoryController : Controller
	{
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
		public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            cm.TAdd(p);
            return RedirectToAction("Index", "Category");

        }

        public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
