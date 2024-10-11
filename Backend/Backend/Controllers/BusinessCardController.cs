using BusinessCardManagement.Backend.Interfaces;
using BusinessCardManagement.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BusinessCardManagement.Backend.Controllers
{
	//testing commit
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

		[HttpGet("ExportCards")]
		public async Task<IActionResult> ExportBusinessCards(string format)
		{

			if (format == "XML")
			{
				var result = businessCardService.ExportBusinessCardsToXML();
				return result;
			}
			else if (format == "CSV")
			{
				byte[] csvBytes = businessCardService.ExportBusinessCardsToCSV();

				if (csvBytes != null)
				{
					var stream = new MemoryStream(csvBytes);
					return File(stream, "text/csv", "BusinessCards.csv");
				}

			}

			return null;

		}

		[HttpPost]
		public async Task<IActionResult> BusinessCard([FromBody] BusinessCard businessCard)
		{


			if (businessCard != null) {

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

			if (id != 0)
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

		[HttpGet("FilterByName")]

		public async Task <IActionResult> FilterByName([FromQuery] string name) { 
		
			if(!name.IsNullOrEmpty()) {
			
			var businessCard=businessCardService.GetBusinessCardByName(name);


				return Ok(businessCard);
			}
			return Ok();

		}

	}
}
