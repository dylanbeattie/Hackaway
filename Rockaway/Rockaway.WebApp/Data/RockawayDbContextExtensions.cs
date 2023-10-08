using Microsoft.Data.Sqlite;
using Serilog;

namespace Rockaway.WebApp.Data;

public static class RockawayDbContextExtensions {

	public static WebApplicationBuilder UseRockawayDbContext(this WebApplicationBuilder builder) {
		var useSqlite = builder.Configuration["database"] == "sqlite";
		if (useSqlite) {
			Log.Information("Running Rockaway.WebApp in Sqlite mode");
			var sqlite = new SqliteConnection("Data Source=:memory:");
			sqlite.Open();
			builder.Services.AddDbContext<RockawayDbContext>(options => options.UseSqlite(sqlite));
		} else {
			Log.Information("Running Rockaway.WebApp in SQL Server mode");
			var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
			builder.Services.AddDbContext<RockawayDbContext>(options => options.UseSqlServer(connectionString));
		}
		return builder;
	}
	public static IApplicationBuilder InitialiseRockawayDatabase(this WebApplication app) {
		var useSqlite = app.Configuration["database"] == "sqlite";
		using var scope = app.Services.CreateScope();
		using var db = scope.ServiceProvider.GetService<RockawayDbContext>() ??
					   throw new("Couldn't resolve service RockawayDbContext");
		if (useSqlite) {
			Log.Information("calling Database.EnsureCreated()");
			lock (db) db.Database.EnsureCreated();
		} else if (app.Environment.IsStaging() || app.Environment.IsProduction()) {
			Log.Information("calling Database.Migrate()");
			db.Database.Migrate();
		}
		return app;
	}
}