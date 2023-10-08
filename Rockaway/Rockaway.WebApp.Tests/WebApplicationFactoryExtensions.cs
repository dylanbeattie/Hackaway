using Microsoft.Extensions.DependencyInjection;
using Rockaway.WebApp.Data;

namespace Rockaway.WebApp.Tests;

public static class WebApplicationFactoryExtensions {
	public static WebApplicationFactory<T> WithTestDatabase<T>(this WebApplicationFactory<T> factory, RockawayDbContext db) where T : class
		=> factory.WithWebHostBuilder(builder => builder.ConfigureServices(services => services.AddSingleton(db)));
}