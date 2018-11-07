using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Ratings
{
    [Authorize(Roles = "Admin, Staff, Member")]
    public class CreateModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public CreateModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Rating Rating { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Rating.RatingTime = DateTime.Now;

            _context.Rating.Add(Rating);
            //await _context.SaveChangesAsync();

            // Once a record is added, create an audit record
            if (await _context.SaveChangesAsync() > 0)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Add Rating Record";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyBookFieldID = 998;
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