using EntityLayer.Concrete;
using System.Reflection.Metadata;

namespace MyProfile.Models
{
    public class MyViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
