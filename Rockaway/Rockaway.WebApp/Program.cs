using Microsoft.Data.Sqlite;
using Rockaway.WebApp.Data;
using Rockaway.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStatusReporter, StatusReporter>();
var sqlite = new SqliteConnection("Data Source=:memory:");
sqlite.Open();
builder.Services.AddDbContext<RockawayDbContext>(options => options.UseSqlite(sqlite));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapGet("/status", (IStatusReporter sr) => sr.GetStatus());
app.Run();
