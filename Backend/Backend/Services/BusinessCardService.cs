using Backend.Data;
using BusinessCardManagement.Backend.Interfaces;
using BusinessCardManagement.Backend.Models;
using System.Linq;

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

		public void ExportBusinessCards()
		{
			throw new NotImplementedException();
		}

		public List<BusinessCard> GetBusinessCards()
		{
			return _context.BusinessCards.ToList();
		}
	}
}
