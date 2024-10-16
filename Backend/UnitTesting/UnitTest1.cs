using Backend.Repositories;
using BusinessCardManagement.Backend.Controllers;
using BusinessCardManagement.Backend.Models;
using BusinessCardManagement.Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Text;

namespace Backend.UnitTests
{

	[TestClass]
	public class BusinessCardTests
	{
		private Mock<IBusinessCardRepository> mockRepository;
		private BusinessCardService service;
		private  BusinessCardsController _controller;


		[TestInitialize]
		public void Setup()
		{
			mockRepository = new Mock<IBusinessCardRepository>();
			service = new BusinessCardService(mockRepository.Object);

		}

		[TestMethod]
		public void TestDeleteById()
		{
			var cardId = 10;
			var businessCard = new BusinessCard { Id = cardId, Name = "Dareen" };

			mockRepository.Setup(repo => repo.GetById(cardId)).Returns(businessCard);

			service.DeleteBusinessCard(cardId);

			mockRepository.Verify(repo => repo.DeleteById(businessCard.Id), Times.Once);

		}

		[TestMethod]
		public void TestGetBusinessCardsByAddress()
		{
		
			var address = "Jordan";
			var expectedCards = new List<BusinessCard>
			{
				new BusinessCard { Id = 1, Name = "Dareen", Address = address },
				new BusinessCard { Id = 2, Name = "Farah", Address = address }
			};

			mockRepository.Setup(repo => repo.GetByAddress(address))
						  .Returns(expectedCards);

			var result = service.GetBusinessCardByAddress(address);

			Assert.AreEqual(2, result.Count);
			Assert.AreEqual("Dareen", result[0].Name);
			Assert.AreEqual("Farah", result[1].Name);
			mockRepository.Verify(repo => repo.GetByAddress(address), Times.Once);
		}
		[TestMethod]
		public void TestCsvImport()
		{
			var csvContent = "Name,Gender,Email,Phone,Address\n1,Dareen,Female,dareen@gmail.com,078394722,Jordan";
			//var stream = new MemoryStream(Encoding.UTF8.GetBytes(csvContent));

			////var result = service.ParseCSV(stream);

			//Assert.IsNotNull(result);
			//Assert.AreEqual("Dareen", result.Name);

		}

		[TestMethod]
		public void TestGetAllBusinessCards()
		{
		


		}
	}
}
