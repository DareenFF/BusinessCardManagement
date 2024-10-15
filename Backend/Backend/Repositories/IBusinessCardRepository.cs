using BusinessCardManagement.Backend.Models;

namespace Backend.Repositories
{

	public interface IBusinessCardRepository
	{
		List<BusinessCard> GetAll();
		void Add(BusinessCard businessCard);
		BusinessCard GetById(int id);
		void DeleteById(int id);

		List<BusinessCard> GetByAddress(string address);


	}
}
