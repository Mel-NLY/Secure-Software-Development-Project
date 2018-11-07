using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Reservations
{
    [Authorize(Roles = "Admin, Staff, Member")]
    public class ReserveDetailsModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public ReserveDetailsModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public Reservation Reservation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Reservation = await _context.Reservation.SingleOrDefaultAsync(m => m.ReservationID == id);

            if (Reservation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
