﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Rockaway.WebApp.Data.Sample;

namespace Rockaway.WebApp.Data;

public class RockawayDbContext : DbContext {
	// We must declare a constructor that takes a DbContextOptions<RockawayDbContext>
	// if we want to use Asp.NET to configure our database connection and provider.
	public RockawayDbContext(DbContextOptions<RockawayDbContext> options) : base(options) { }

	public DbSet<Artist> Artists { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);
		// Override EF Core's default table naming (which pluralizes entity names)
		// and use the same names as the C# classes instead
		modelBuilder.Model.GetEntityTypes().ToList().ForEach(e => e.SetTableName(e.DisplayName()));
		SampleData.Populate(modelBuilder);
	}
}