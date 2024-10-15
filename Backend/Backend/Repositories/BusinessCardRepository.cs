using Backend.Data;
using BusinessCardManagement.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
	public class BusinessCardRepository : IBusinessCardRepository
	{

		private readonly BusinessCardContext _dbcontext;
		public BusinessCardRepository(BusinessCardContext context) {
		
			_dbcontext=context;
		}	
		void IBusinessCardRepository.Add(BusinessCard businessCard)
		{

			_dbcontext.Add(businessCard);
			_dbcontext.SaveChanges();
		}

		void IBusinessCardRepository.DeleteById(int id)
		{

			var businessCard = _dbcontext.BusinessCards.Where(x => x.Id == id).FirstOrDefault();
			if (businessCard != null)
			{
				_dbcontext.BusinessCards.Remove(businessCard);
				_dbcontext.SaveChanges();

			}
		}

		List<BusinessCard> IBusinessCardRepository.GetAll()
		{
			return _dbcontext.BusinessCards.ToList();
		}

		BusinessCard IBusinessCardRepository.GetById(int id)
		{

			return _dbcontext.BusinessCards.Where(x => x.Id == id).FirstOrDefault();
		}

		List<BusinessCard> IBusinessCardRepository.GetByAddress(string address)
		{
			List<BusinessCard> list = _dbcontext.BusinessCards.Where(x => x.Address.Contains(address)).ToList();


			return list;


		}
	}
}
