using BusinessCardManagement.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public class BusinessCardContext:DbContext
	{

		public BusinessCardContext(DbContextOptions<BusinessCardContext> options):base(options) { }
		

		public DbSet<BusinessCard> BusinessCards { get; set; }

	}
}
