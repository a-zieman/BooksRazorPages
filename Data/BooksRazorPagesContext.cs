using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksRazorPages.Models;

namespace BooksRazorPages.Data
{
    public class BooksRazorPagesContext : DbContext
    {
        public BooksRazorPagesContext (DbContextOptions<BooksRazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<BooksRazorPages.Models.Book> Book { get; set; } = default!;
    }
}
