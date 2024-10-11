using Backend.Data;
using BusinessCardManagement.Backend.Interfaces;
using BusinessCardManagement.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BusinessCardManagement.Backend.Services
{
	public class BusinessCardService : IBusinessCardService
	{
		private readonly BusinessCardContext _context;
		public BusinessCardService(BusinessCardContext context) {
		_context = context;
		}	
		public void CreateBusinessCard(BusinessCard businessCard)
		{
			
			_context.BusinessCards.Add(businessCard);
			_context.SaveChanges();
		}

		public void DeleteBusinessCard(int id)
		{
			var businessCard = _context.BusinessCards.Where(x => x.Id==id).FirstOrDefault();
			if(businessCard != null)
			{
				_context.BusinessCards.Remove(businessCard);
				_context.SaveChanges();

			}
		}

		public FileStreamResult ExportBusinessCardsToXML()
		{
			List<BusinessCard> list = GetBusinessCards();

			if (list != null)
			{
				XmlSerializer serializer = new XmlSerializer(typeof(List<BusinessCard>));
				var stream = new MemoryStream(); 

				serializer.Serialize(stream, list);
				stream.Position = 0; 

				return new FileStreamResult(stream, "application/xml")
				{
					FileDownloadName = "BusinessCards.xml"
				};
			}
			return null;
		}
		public byte[] ExportBusinessCardsToCSV()
		{
			List<BusinessCard> list = GetBusinessCards(); // Your logic to get business cards

			if (list != null && list.Count > 0)
			{
				var csv = new StringBuilder();
				csv.AppendLine("Id,Name,Email,Address"); // Add headers

				foreach (var card in list)
				{
					csv.AppendLine($"{card.Id},{card.Name},{card.Email},{card.Address}"); // Adjust properties as needed
				}

				return Encoding.UTF8.GetBytes(csv.ToString()); // Return as byte array
			}

			return null; // Handle the case where the list is null or empty
		}


		public List<BusinessCard> GetBusinessCards()
		{
			return _context.BusinessCards.ToList();
		}

		public BusinessCard GetBusinessCardByName(string name) {


			var businessCard = _context.BusinessCards.Where(x=>x.Name==name.Trim().ToUpper()).FirstOrDefault();

			return businessCard;


		}

		public void ParseXML()
		{

		}
		public void ParseCSV()
		{

		}
	}
}
