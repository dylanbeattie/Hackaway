using Microsoft.AspNetCore.Identity;
using Rockaway.WebApp.Authorization;
using Rockaway.WebApp.Data;
using Rockaway.WebApp.Services;
using Serilog;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();
builder.UseRockawayDbContext();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<RockawayDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStatusReporter, StatusReporter>();
builder.Services.AddEmailDomainAuthorization("admin", "rockaway.dev");
var app = builder.Build();

app.InitialiseRockawayDatabase();
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(name: "admin", pattern: "{area=admin}/{controller=Home}/{action=Index}/{id?}")
	.RequireAuthorization("admin");
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapGet("/status", (IStatusReporter sr) => sr.GetStatus());
app.Run();