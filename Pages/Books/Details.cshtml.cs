using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksRazorPages.Data;
using BooksRazorPages.Models;
using Microsoft.AspNetCore.Authorization;

namespace BooksRazorPages.Pages.Books
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly BooksRazorPages.Data.BooksRazorPagesContext _context;

        public DetailsModel(BooksRazorPages.Data.BooksRazorPagesContext context)
        {
            _context = context;
        }

      public Book Book { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}
