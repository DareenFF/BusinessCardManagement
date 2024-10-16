using BusinessCardManagement.Backend.Interfaces;
using BusinessCardManagement.Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BusinessCardManagement.Backend.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BusinessCardsController : ControllerBase
	{
		private readonly IBusinessCardService businessCardService;
		public BusinessCardsController(IBusinessCardService service) {

			businessCardService = service;

		}

		[HttpGet]
		public async Task<IActionResult> BusinessCards()
		{

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
		
				if (businessCard == null)
				{
					return BadRequest("Business card data is required.");
				}

				if (!ModelState.IsValid)
				{
					return BadRequest(ModelState);
				}

				try
				{
					businessCardService.CreateBusinessCard(businessCard);

					return CreatedAtAction(nameof(BusinessCard), new { id = businessCard.Id }, businessCard);
				}
				catch (Exception ex)
				{
					return StatusCode(500, "An error occurred while processing your request.");
				}
							
			
		}

		[HttpPost("UploadFile")]
		public async Task<IActionResult> BusinessCard([FromForm] IFormFile file)
		{
			if (file == null)
			{
				return BadRequest("No file was uploaded.");
			}

			BusinessCard extractedCard = null;

			if (file.FileName.EndsWith(".csv"))
			{
				extractedCard = businessCardService.ParseCSV(file);
			}
			else if (file.FileName.EndsWith(".xml"))
			{
				extractedCard = businessCardService.ParseXML(file);
			}
			else
			{
				return BadRequest("Only accepts CSV or XML files");
			}

			if (extractedCard == null)
			{
				return BadRequest("Error in parsing");
			}

			businessCardService.CreateBusinessCard(extractedCard);
			return CreatedAtAction(nameof(BusinessCard), new { id = extractedCard.Id }, extractedCard);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> BusinessCard(int id)
		{

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

		[HttpGet("FilterByAddress")]

		public async Task <IActionResult> FilterByAddress(string address) { 
		
			if(!address.IsNullOrEmpty()) {
			
			var businessCards=businessCardService.GetBusinessCardByAddress(address);


				return Ok(businessCards);
			}
			return Ok();

		}

	}
}
