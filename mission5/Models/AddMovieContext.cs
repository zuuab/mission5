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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }

                );


            mb.Entity<AddMovie>().HasData(
                new AddMovie
                {
                    MovieId = 1,
                    CategoryId = 2,
                    Title = "The Waterboy",
                    Year = 1998,
                    Director = "Frank Coraci",
                    Rating = "PG-13",
                    Edited = "No"
                },
                new AddMovie
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "Eurovision Song Contest: The Story of Fire Saga",
                    Year = 2020,
                    Director = "David Dobkin",
                    Rating = "PG-13",
                    Edited = "No"
                }, new AddMovie
                {
                    MovieId = 3,
                    CategoryId = 1,
                    Title = "300",
                    Year = 2006,
                    Director = "Zack Snyder",
                    Rating = "R",
                    Edited = "No"
                }
                );
        }
    }
}
