using System.ComponentModel.DataAnnotations;

namespace BusinessCardManagement.Backend.Models
{
	public class BusinessCard
	{

		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Gender { get; set; }
		 public DateOnly DOB { get; set; }
		[EmailAddress]
		public string? Email { get; set; }
		[Phone]
		public string? Phone { get; set; }
		public string? Address { get; set; }

		public byte[]? Photo { get; set; }
	}
}
