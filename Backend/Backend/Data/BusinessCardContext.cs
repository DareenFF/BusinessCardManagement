using BusinessCardManagement.Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend.Data
{
	public class BusinessCardContext:DbContext
	{

		public BusinessCardContext(DbContextOptions<BusinessCardContext> options):base(options) { }
		

		public DbSet<BusinessCard> BusinessCards { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BusinessCard>()
				.Property(p => p.DOB)
				.HasColumnType("date"); 
		}
	}
}
