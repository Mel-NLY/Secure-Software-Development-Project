using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Libraries
{
    public class DetailsModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public DetailsModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public Library Library { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Library = await _context.Library.SingleOrDefaultAsync(m => m.Id == id);

            if (Library == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
