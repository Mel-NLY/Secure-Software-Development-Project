using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Feedbacks
{
    [Authorize(Roles = "Admin, Staff")]
    public class DetailsModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public DetailsModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public Feedback Feedback { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Feedback = await _context.Feedback.SingleOrDefaultAsync(m => m.feedbackId == id);

            if (Feedback == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
