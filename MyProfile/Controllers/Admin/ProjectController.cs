using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyProfile.Models;
using System.Reflection.Metadata;

namespace MyProfile.Controllers.Admin
{
    public class ProjectController : Controller
    {
        ProjectManager pm = new ProjectManager(new EfProjectRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            var values = pm.GetList();
            return View(values);
        }

		[HttpGet]
		public IActionResult ProjectAdd()
		{

            List<SelectListItem> categoryvalues = (from x in cm.GetList() select new SelectListItem { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }
        [HttpPost]
		public IActionResult ProjectAdd(Project p, IFormFile ProjectImage)
		{
            if (ProjectImage != null && ProjectImage.Length > 0)
            {
                // dosya adı ve uzantısı
                var fileName = Path.GetFileName(ProjectImage.FileName);
                var fileExtension = Path.GetExtension(fileName);

                // dosya adı değiştirme
                var newFileName = Guid.NewGuid() + fileExtension;

                // dosya kaydedilme yolu
                var location = Directory.GetCurrentDirectory();
                var path = Path.Combine(location, "wwwroot/images/", newFileName);

                // dosyayı kaydetme
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    ProjectImage.CopyTo(stream);
                }

                // veritabanına kaydetme
                p.ProjectImage = "/images/" + newFileName;
            }

            pm.TAdd(p);
			return RedirectToAction("Index", "Admin");

		}
        public IActionResult ProjectDelete(int id)
        {
            var value = pm.TGetById(id);
            pm.TDelete(value);
            return RedirectToAction("Index");
        }

        public IActionResult ProjectDetails(int id)
        {
            ViewBag.i = id;
            var values = pm.GetList(); // retrieve a collection of projects
            var project = values.FirstOrDefault(p => p.ProjectID == id); // retrieve the project with the specified id
            return View(new List<Project> { project }); // pass a list containing a single project to the view
        }

    }
}
