using BusinessCardManagement.Backend.Models;

namespace BusinessCardManagement.Backend.Interfaces
{
	 public interface IBusinessCardService
	{

		 List<BusinessCard> GetBusinessCards();
		 void CreateBusinessCard(BusinessCard businessCard);
		 void DeleteBusinessCard(int id);
		 void ExportBusinessCards();
	}
}
