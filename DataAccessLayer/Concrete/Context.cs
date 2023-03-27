using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context:DbContext
	{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
    {
				optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyProfile;Integrated Security=True");
			}
		}

		public DbSet<Project>? Projects { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<Director>? Directors { get; set; }
	}
}
