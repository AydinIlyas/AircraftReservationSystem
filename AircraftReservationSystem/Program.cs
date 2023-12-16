using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using AircraftReservationSystem.Utility;
using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.DataAccess.Repository;
using AircraftReservationSystem.Areas.User.Services;
using AircraftReservationSystem.Areas.Admin.Services;
using AircraftReservationSystem.Areas.Admin.Services.Interfaces;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.DataAccess.DbInitializer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddIdentity<Passenger,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});
builder.Services.AddRazorPages();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
SeedDatabase();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
	endpoints.MapRazorPages();
	endpoints.MapControllers(); // Map Web API controllers

	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");
});

app.Run();

void SeedDatabase()
{
	using (var scope = app.Services.CreateScope())
	{
		var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
		dbInitializer.Initialize();
	}
}