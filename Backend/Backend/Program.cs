//using BusinessCardManagement.Backend.Interfaces;
//using BusinessCardManagement.Backend.Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//builder.Services.AddScoped<IBusinessCardService, BusinessCardService>();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//	app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();

//app.MapControllers();


//app.MapControllerRoute(
//	name: "default",
//	pattern: "{controller}/{action=Index}/{id?}");

//app.MapFallbackToFile("index.html");

//app.Run();
using BusinessCardManagement.Backend.Interfaces;
using BusinessCardManagement.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();           // Register Swagger services

builder.Services.AddScoped<IBusinessCardService, BusinessCardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.


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
app.UseAuthorization(); // Add this if you are using authentication/authorization

app.MapControllers();

app.Run();
