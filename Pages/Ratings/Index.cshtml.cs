using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Ratings
{
    public class IndexModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;
        private string searchString;

        public IndexModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public IList<Rating> Rating { get;set; }

        public async Task OnGetAsync()
        {
            var rating = from m in _context.Rating
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                rating = rating.Where(s => s.BookTitle.Contains(searchString));
            }

            Rating = await rating.ToListAsync();
        }
    }
}
