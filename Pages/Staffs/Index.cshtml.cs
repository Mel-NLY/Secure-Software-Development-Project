using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Staffs
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public IndexModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public IList<Staff> Staff { get;set; }

        public async Task OnGetAsync()
        {
            Staff = await _context.Staff.ToListAsync();
        }
    }
}
