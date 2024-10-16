using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BusinessCardManagement.Backend.Models
{
	[Serializable]
	[XmlRoot("BusinessCard")] 
	public class BusinessCard
	{
		[XmlElement("Id")] 
		public int Id { get; set; }

		[XmlElement("Name")]
		[Required]
		public string? Name { get; set; }

		[XmlElement("Gender")]
		[Required]
		public string? Gender { get; set; }

		[Required]
		[XmlElement("DOB")] 
		public DateTime DOB { get; set; }

		[Required]
		[XmlElement("Email")] 
		public string? Email{ get; set; }

		[Required]
		[XmlElement("Phone")] 
		public string? Phone { get; set; }

		[Required]
		[XmlElement("Address")] 
		public string? Address { get; set; }

		[XmlElement("Photo")] 
		public byte[]? Photo { get; set; }
	}
}
