using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ChinookMusic2.Models
{
    public class ChinookContext: DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Album> Album { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .ToTable("Artist")
                .HasKey(a => a.ArtistId);

            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Album>()
                .ToTable("Album")
                .HasKey(alb => alb.AlbumId);

            modelBuilder.Entity<Genre>()
                .ToTable("Genre")
                .HasKey(g => g.GenreId);
        }


    }
}