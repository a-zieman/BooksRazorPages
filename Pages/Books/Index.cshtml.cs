using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksRazorPages.Data;
using BooksRazorPages.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksRazorPages.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BooksRazorPages.Data.BooksRazorPagesContext _context;

        public IndexModel(BooksRazorPages.Data.BooksRazorPagesContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;


        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var books = from m in _context.Book
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }
            if (_context.Book != null)
            {
                Book = await books.ToListAsync();
            }
        }
    }
}
