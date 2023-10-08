﻿namespace Rockaway.WebApp.Data.Sample
{
    public partial class SampleData
    {
        private static Guid TestGuid(int seed, char pad) => new(seed.ToString().PadLeft(32, pad));

        public static void Populate(ModelBuilder modelBuilder)
        {
            // Watch out for dependencies here; entities must be seeded in order
            // otherwise SQL will throw a foreign key constraint if e.g. we try
            // to create a show for a venue which doesn't exist yet.
            modelBuilder.Entity<Artist>().HasData(Artists.AllArtists);
            modelBuilder.Entity<Venue>().HasData(Venues.AllVenues);
        }
    }
}
