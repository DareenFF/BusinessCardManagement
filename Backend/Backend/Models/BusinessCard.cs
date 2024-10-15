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
		public string? Name { get; set; }

		[XmlElement("Gender")] 
		public string? Gender { get; set; }

		[XmlElement("DOB")] 
		public DateTime DOB { get; set; }

		[XmlElement("Email")] 
		public string? Email{ get; set; }

		[XmlElement("Phone")] 
		public string? Phone { get; set; }

		[XmlElement("Address")] 
		public string? Address { get; set; }

		[XmlElement("Photo")] 
		public byte[]? Photo { get; set; }
	}
}
