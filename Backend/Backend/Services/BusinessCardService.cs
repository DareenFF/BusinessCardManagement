using Backend.Data;
using Backend.Repositories;
using BusinessCardManagement.Backend.Interfaces;
using BusinessCardManagement.Backend.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BusinessCardManagement.Backend.Services
{
	public class BusinessCardService : IBusinessCardService
	{
		private readonly BusinessCardContext _context;

		private readonly IBusinessCardRepository _repository;

		public BusinessCardService(BusinessCardContext context, IBusinessCardRepository repository) {
		_context = context;
			_repository = repository;

		}
		public void CreateBusinessCard(BusinessCard businessCard)
		{
			
			_repository.Add(businessCard);
		}

		public void DeleteBusinessCard(int id)
		{
			_repository.DeleteById(id);			
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
			List<BusinessCard> list = GetBusinessCards(); 

			if (list != null && list.Count > 0)
			{
				var csv = new StringBuilder();
				csv.AppendLine("Id,Name,Email,Address"); 

				foreach (var card in list)
				{
					csv.AppendLine($"{card.Id},{card.Name},{card.Email},{card.Address}"); 
				}

				return Encoding.UTF8.GetBytes(csv.ToString()); 
			}

			return null; 
		}


		public List<BusinessCard> GetBusinessCards()
		{
			return _repository.GetAll();
		}

		public List<BusinessCard> GetBusinessCardByAddress(string address) {


			return _repository.GetByAddress(address);


		}

		public BusinessCard? ParseXML(IFormFile file)
		{
			using var stream = file.OpenReadStream(); 
			var serializer = new XmlSerializer(typeof(BusinessCard)); 

			return (BusinessCard?)serializer.Deserialize(stream);
		}
		public BusinessCard ParseCSV(IFormFile file)
		{
			using var reader = new StreamReader(file.OpenReadStream());
			using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

			csv.Context.RegisterClassMap<BusinessCardMap>();


			try
			{
				csv.Read();
				csv.ReadHeader(); 

				if (csv.Read())
				{
					return csv.GetRecord<BusinessCard>();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error parsing CSV: {ex.Message}");
			}

			return null; 
		}


	}
}

