using Microsoft.EntityFrameworkCore;
using BooksRazorPages.Data;

namespace BooksRazorPages.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BooksRazorPagesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BooksRazorPagesContext>>()))
        {
            if (context == null || context.Book == null)
            {
                throw new ArgumentNullException("Null BooksRazorPagesContext");
            }

            // Look for any movies.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }

            context.Book.AddRange(
                new Book
                {
                    Title = "Hobbit, czyli tam i z powrotem",
                    Author = "J.R.R. Tolkien",
                    ISBN = "9788324008335",
                    PublicationDate = DateTime.Parse("1937-09-21")
                },

                new Book
                {
                    Title = "Harry Potter i Kamień Filozoficzny",
                    Author = "J.K. Rowling",
                    ISBN = "9780747532743",
                    PublicationDate = DateTime.Parse("1997-06-26")
                },

                new Book
                {
                    Title = "Gra o tron",
                    Author = "George R.R. Martin",
                    ISBN = "9780553103540",
                    PublicationDate = DateTime.Parse("1996-08-06")
                }
            );

            context.SaveChanges();
        }
    }
}