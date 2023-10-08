using Microsoft.Extensions.DependencyInjection;
using Rockaway.WebApp.Services;
using Shouldly;
using System.Text.Json;

namespace Rockaway.WebApp.Tests;

public class EndpointTests {
	[Fact]
	public async Task Status_Endpoint_Returns_Success() {
		var db = await TestDatabase.CreateAsync();
		var factory = new WebApplicationFactory<Program>().WithTestDatabase(db);
		var client = factory.CreateClient();
		var result = await client.GetAsync("/status");
		result.EnsureSuccessStatusCode();
	}

	public class FakeStatusReporter : IStatusReporter {
		public static readonly ServerStatus Status = new() {
			Assembly = "Rockaway.WebApp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null",
			DateTime = new(2021, 2, 3, 4, 5, 6, TimeSpan.Zero),
			Hostname = "hostname",
			Modified = new(2021, 2, 3, 4, 5, 6, 7, TimeSpan.Zero)
		};

		public ServerStatus GetStatus() => Status;
	}

	[Fact]
	public async Task Status_Endpoint_Returns_Correct_Json() {
		var db = await TestDatabase.CreateAsync();
		var factory = new WebApplicationFactory<Program>().WithTestDatabase(db);
		var client = factory.WithWebHostBuilder(builder => builder.ConfigureServices(services => {
			services.AddScoped<IStatusReporter>(_ => new FakeStatusReporter());
		})).CreateClient();
		JsonSerializerOptions options = new(JsonSerializerDefaults.Web);
		var json = await client.GetStringAsync("/status");
		var status = JsonSerializer.Deserialize<ServerStatus>(json, options);
		status.ShouldBeEquivalentTo(FakeStatusReporter.Status);
	}
}