using Microsoft.EntityFrameworkCore;
using Lab3.Data;

namespace Lab3.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Lab3Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Lab3Context>>()))
            {
                if (context == null || context.Books == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Books.Any())
                {
                    return;   // DB has been seeded
                }

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Harry Potter and the Philosphers Stone",
                        publication = DateTime.Parse("1989-2-12"),
                        authorID = 2,
                        publisherID = 4,
                        coverpage = "https://res.cloudinary.com/bloomsbury-atlas/image/upload/w_360,c_scale,dpr_1.5/jackets/9781408855652.jpg"
                    },

                    new Book
                    {
                        Title = "Star Wars Episode 3 Revenge of the Sith",
                        publication = DateTime.Parse("1972-2-12"),
                        authorID = 6,
                        publisherID = 4,
                        coverpage = "https://www.coverwhiz.com/uploads/movies/star-wars-episode-iii-revenge-of-the-sith.jpg"
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
