using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Ratings
{
    public class DetailsModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public DetailsModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public Rating Rating { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rating = await _context.Rating.SingleOrDefaultAsync(m => m.RatingId == id);

            if (Rating == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
