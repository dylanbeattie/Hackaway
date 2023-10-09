using AngleSharp;
using Shouldly;

namespace Rockaway.WebApp.Tests;

public class PagesTests {
	[Theory]
	[InlineData("/")]
	[InlineData("/privacy")]
	public async Task Page_Returns_Success(string url) {
		var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var result = await client.GetAsync(url);
		result.EnsureSuccessStatusCode();
	}

	protected IBrowsingContext browsingContext => BrowsingContext.New(Configuration.Default);

	[Fact]
	public async Task Homepage_Title_Has_Correct_Content() {
		var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var html = await client.GetStringAsync("/");
		var dom = await browsingContext.OpenAsync(req => req.Content(html));
		var title = dom.QuerySelector("title");
		title.ShouldNotBeNull();
		title.InnerHtml.ShouldBe("Rockaway");
	}
}