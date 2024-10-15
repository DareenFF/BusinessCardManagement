using BusinessCardManagement.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardManagement.Backend.Interfaces
{
	 public interface IBusinessCardService
	{

		 List<BusinessCard> GetBusinessCards();
		 void CreateBusinessCard(BusinessCard businessCard);
		 void DeleteBusinessCard(int id);
		FileStreamResult ExportBusinessCardsToXML();
		byte[] ExportBusinessCardsToCSV();

		BusinessCard ParseXML(IFormFile file);

		BusinessCard ParseCSV(IFormFile file);

		List<BusinessCard> GetBusinessCardByAddress(string address);
	}
}
