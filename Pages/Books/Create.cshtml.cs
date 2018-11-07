using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSDAssignmentBOX.Models;
using Microsoft.AspNetCore.Authorization;

namespace SSDAssignmentBOX.Pages.Books
{
    [Authorize(Roles = "Admin, Staff")]
    public class CreateModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public CreateModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //throw new Exception("Test Error");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        //run when the page posts form data
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Book.Availability = "Available";
            _context.Book.Add(Book);
            //await _context.SaveChangesAsync();

            // Once a record is added, create an audit record
            if (await _context.SaveChangesAsync() > 0)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Add Book Record";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyBookFieldID = Book.ID;
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}