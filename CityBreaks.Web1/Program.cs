using CityBreaks.Web1.Data;
using CityBreaks.Web1.Interfaces;
using CityBreaks.Web1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Inje��o de depend�ncia
builder.Services.AddDbContext<CityBreaksContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICityService, CityService>();
// Registra o servi�o de propriedades
builder.Services.AddScoped<IPropertyService, PropertyService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
