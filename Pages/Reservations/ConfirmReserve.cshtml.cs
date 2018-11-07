using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Reservations
{
    [Authorize(Roles = "Admin, Staff, Member")]
    public class ConfirmReserveModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public ConfirmReserveModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public Reservation Reservation { get; set; }

        //[BindProperty]
        //public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            Book = await _context.Book.SingleOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Reservation.dueDate = (DateTime.Now.AddDays(21));
            Reservation.dateBorrowed = DateTime.Now;
            Reservation.ISBN = Book.ISBN;
            Reservation.Title = Book.Title;
            Reservation.Author = Book.Author;
            Reservation.Summary = Book.Summary;
            Reservation.DatePublished = Book.DatePublished;
            Reservation.Genre = Book.Genre;
            Reservation.Language = Book.Language;
            Reservation.Characters = Book.Characters;
            Reservation.DateReceived = Book.DateReceived;
            Reservation.Location = Book.Location;
            Reservation.Availability = Book.Availability;
            // Get current logged-in user
            var userID = User.Identity.Name.ToString();
            Reservation.Borrower = userID;
            _context.Reservation.Add(Reservation);

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                // Once a record is added, create an audit record
                if (await _context.SaveChangesAsync() > 0)
                {
                    // Create an auditrecord object
                    var auditrecord = new AuditRecord();
                    auditrecord.AuditActionType = "Add Reservation Record";
                    auditrecord.DateTimeStamp = DateTime.Now;
                    auditrecord.KeyBookFieldID = Reservation.ReservationID;
                    // Get current logged-in user
                    var UserID = User.Identity.Name.ToString();
                    auditrecord.Username = UserID;
                    _context.AuditRecords.Add(auditrecord);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Books/Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.ID == id);
        }
    }
}
