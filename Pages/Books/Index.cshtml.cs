using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public IndexModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        public SelectList Genres { get; set; }
        public string BookGenre { get; set; }

        public string SearchString { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task OnGetAsync(string bookGenre, string SearchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.Book
                                            orderby b.Genre
                                            select b.Genre;

            var books = from b in _context.Book
                         select b;

            if (!String.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }

            if (!String.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(x => x.Genre == bookGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
