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
    public class IndexModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public IndexModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public IList<Feedback> Feedback { get;set; }

        public async Task OnGetAsync()
        {
            Feedback = await _context.Feedback.ToListAsync();
        }
    }
}
