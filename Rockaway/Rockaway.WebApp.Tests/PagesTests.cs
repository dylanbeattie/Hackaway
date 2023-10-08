using Microsoft.AspNetCore.Mvc.Testing;

namespace Rockaway.WebApp.Tests;

public class PagesTests {
	[Fact]
	public async Task Index_Page_Returns_Success() {
		var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var result = await client.GetAsync("/");
		result.EnsureSuccessStatusCode();
	}
}