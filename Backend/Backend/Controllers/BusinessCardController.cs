using BusinessCardManagement.Backend.Interfaces;
using BusinessCardManagement.Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessCardManagement.Backend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BusinessCardController : ControllerBase
	{
		private readonly IBusinessCardService businessCardService;
		public BusinessCardController(IBusinessCardService service) {

			businessCardService = service;
		
		}

		[HttpGet("get")]
		public async Task<IActionResult> BusinessCards()
		{
			//return all business cards

			List<BusinessCard> list = businessCardService.GetBusinessCards();

			return Ok(list);
		}

		[HttpGet]
		public async Task<IActionResult> ExportBusinessCards(int id)
		{
			return Ok();
			//export all business cards
		}

		[HttpPost]
		public async Task<IActionResult> BusinessCard([FromBody] BusinessCard businessCard)
		{


			if(businessCard != null) {

				try
				{
					businessCardService.CreateBusinessCard(businessCard);
					return Ok(201);

				}
				catch (Exception)
				{

					throw;
				}			
			}
			//create a new business card
			return Ok();
		}

		

		[HttpDelete("{id}")]
		public async Task<IActionResult> BusinessCard(int id)
		{
			//delete specific business card

			if(id != 0)
			{
				try
				{
					businessCardService.DeleteBusinessCard(id);
					return NoContent();
				}
				catch (Exception)
				{

					throw;
				}



			}
			return Ok();

		}
	}
}
