using BusinessCardManagement.Backend.Models;
using CsvHelper.Configuration;

public class BusinessCardMap : ClassMap<BusinessCard>
{
	public BusinessCardMap()
	{
		Map(m => m.Name);
		Map(m => m.Gender);
		Map(m => m.DOB);
		Map(m => m.Email);
		Map(m => m.Phone);
		Map(m => m.Address);
		Map(m => m.Photo);

	}
}