
using Backend.Data;
using BusinessCardManagement.Backend.Interfaces;
using BusinessCardManagement.Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;




var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins",
		builder =>
		{
			builder.AllowAnyOrigin()
				   .AllowAnyMethod()
				   .AllowAnyHeader();
		});
});
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();         

builder.Services.AddScoped<IBusinessCardService, BusinessCardService>();
var configuration = builder.Configuration;

builder.Services.AddDbContext<BusinessCardContext>(options =>


options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAllOrigins"); 

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
else
{
	app.UseHsts();
}
app.UseAuthorization(); 

app.MapControllers();

app.Run();
