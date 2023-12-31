using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Rockaway.WebApp.Data.Sample;

// ReSharper disable StringLiteralTypo

namespace Rockaway.WebApp.Data;

public class RockawayDbContext : IdentityDbContext<IdentityUser> {
	// We must declare a constructor that takes a DbContextOptions<RockawayDbContext>
	// if we want to use Asp.NET to configure our database connection and provider.
	public RockawayDbContext(DbContextOptions<RockawayDbContext> options) : base(options) { }

	public DbSet<Artist> Artists { get; set; } = null!;
	public DbSet<Venue> Venues { get; set; } = null!;
	public DbSet<Show> Shows { get; set; } = null!;
	public DbSet<TicketOrder> TicketOrders { get; set; } = null!;
	public DbSet<Ticket> Tickets { get; set; } = null!;
	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);
		// Override EF Core's default table naming (which pluralizes entity names)
		// and use the same names as the C# classes instead
		var rockawayEntities = modelBuilder.Model.GetEntityTypes()
			.Where(e => e.ClrType.Namespace == typeof(Artist).Namespace);
		foreach (var entity in rockawayEntities) entity.SetTableName(entity.DisplayName());

		modelBuilder.Entity<TicketOrder>(entity => {
			// Store enums in the database as their string name
			// (InProgress, Cancelled) rather than numeric value (1,2,3)
			entity.Property(order => order.Status).HasConversion<string>();
		});

		modelBuilder.Entity<TicketType>(entity => {
			entity.Property(tt => tt.Price).HasColumnType("money");
		});

		modelBuilder.Entity<Show>(entity => {
			entity.HasMany(show => show.SupportSlots).WithOne(slot => slot.Show).OnDelete(DeleteBehavior.Cascade);
			entity.HasMany(show => show.TicketTypes).WithOne(ticketType => ticketType.Show).OnDelete(DeleteBehavior.Cascade);
			entity.HasOne(show => show.Venue).WithMany(venue => venue.Shows);
			entity.HasOne(show => show.HeadlineArtist).WithMany(artist => artist.HeadlineShows);
			entity.HasKey(
				nameof(Show.Venue) + nameof(Show.Venue.Id),
				nameof(Show.Date)
			);
			entity.Navigation(show => show.Venue).AutoInclude();
			entity.Navigation(show => show.HeadlineArtist).AutoInclude();
			entity.Ignore(show => show.SupportArtists);
		});

		modelBuilder.Entity<Artist>(entity => {
			entity.HasMany(artist => artist.HeadlineShows).WithOne(show => show.HeadlineArtist).OnDelete(DeleteBehavior.Restrict);
			entity.HasMany(artist => artist.SupportSlots).WithOne(slot => slot.Artist).OnDelete(DeleteBehavior.Restrict);
		});

		modelBuilder.Entity<Ticket>(entity => {
			entity.HasOne(item => item.Order).WithMany(order => order.Tickets).OnDelete(DeleteBehavior.Cascade);
			entity.HasOne(item => item.TicketType).WithMany().OnDelete(DeleteBehavior.Restrict);
		});

		modelBuilder.Entity<SupportSlot>(entity => {
			entity.HasOne(slot => slot.Artist).WithMany(artist => artist.SupportSlots);
			entity.HasKey(
				nameof(SupportSlot.Position),
				nameof(SupportSlot.Show) + nameof(SupportSlot.Show.Date),
				nameof(SupportSlot.Show) + nameof(SupportSlot.Show.Venue) + nameof(SupportSlot.Show.Venue.Id));
		});

		SampleData.Populate(modelBuilder);

		modelBuilder.Entity<IdentityUser>().HasData(SampleData.Users.Admin);
	}
}