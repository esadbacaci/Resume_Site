using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Project
    {
        [Key]

        public int ProjectID { get; set; }
		public string ProjectName { get; set; }
		public string ProjectDescription { get; set; }
		public string? ProjectURL { get; set; }
        public string ProjectImage { get; set; }
		public DateTime ProjectDate { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }


    }
}
