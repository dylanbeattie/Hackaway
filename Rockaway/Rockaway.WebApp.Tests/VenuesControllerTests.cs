using System.Net;
using Microsoft.AspNetCore.Mvc;
using Rockaway.WebApp.Controllers;
using Rockaway.WebApp.Data.Entities;
using Shouldly;

namespace Rockaway.WebApp.Tests;

public class VenuesControllerTests {
	[Fact]
	public async Task CreateVenueWithInvalidCountryCodeReturnsError() {
		var c = new VenuesController(null!);
		var post = new Venue { CountryCode = "XX" };
		var result = await c.Create(post) as ViewResult;
		result.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);
	}

	[Fact]
	public async Task CreateVenueWithValidCountryCreatesCountry() {
		var db = await TestDatabase.CreateAsync();
		var c = new VenuesController(db);
		var venue = new Venue {
			Name = "Test Venue", Address = "123 Test Street", City = "Test", CountryCode = "PT",
			Telephone = "1234", WebsiteUrl = "https://example.com",
			Slug = "test-venue"
		};
		await c.Create(venue);
		var created = db.Venues.Single(v => v.Name == "Test Venue");
		created.ShouldBeEquivalentTo(venue);
	}
}