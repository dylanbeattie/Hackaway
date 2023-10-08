using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Rockaway.WebApp.Data;

namespace Rockaway.WebApp.Tests;

public class TestDatabase {
	public static async Task<RockawayDbContext> CreateAsync(string? dbName = null) {
		dbName ??= Guid.NewGuid().ToString();
		var sqlite = new SqliteConnection($"Data Source={dbName};Mode=Memory;Cache=Shared");
		await sqlite.OpenAsync();
		var options = new DbContextOptionsBuilder<RockawayDbContext>().UseSqlite(sqlite).Options;
		var db = new RockawayDbContext(options);
		await db.Database.EnsureCreatedAsync();
		return db;
	}
}