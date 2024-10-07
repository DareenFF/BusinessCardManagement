
using BusinessCardManagement.Backend.Interfaces;
using BusinessCardManagement.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();         

builder.Services.AddScoped<IBusinessCardService, BusinessCardService>();

var app = builder.Build();



app.UseHttpsRedirection();
app.UseRouting();

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
