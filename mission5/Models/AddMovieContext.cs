using System;
using Microsoft.EntityFrameworkCore;

namespace mission5.Models
{
    public class AddMovieContext: DbContext
    {
        //Constructor
        public AddMovieContext(DbContextOptions<AddMovieContext> options) : base (options)
        {
            //Leave blank for now
        }
        public DbSet<AddMovie> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<AddMovie>().HasData(
                new AddMovie
                {
                    MovieId = 1,
                    Category = "Comedy",
                    Title = "The Waterboy",
                    Year = 1998,
                    Director = "Frank Coraci",
                    Rating = "PG-13",
                    Edited = false
                },
                new AddMovie
                {
                    MovieId = 2,
                    Category = "Comedy",
                    Title = "Eurovision Song Contest: The Story of Fire Saga",
                    Year = 2020,
                    Director = "David Dobkin",
                    Rating = "PG-13",
                    Edited = false
                }, new AddMovie
                {
                    MovieId = 3,
                    Category = "Action",
                    Title = "300",
                    Year = 2006,
                    Director = "Zack Snyder",
                    Rating = "R",
                    Edited = false
                }
                );
        }
    }
}
