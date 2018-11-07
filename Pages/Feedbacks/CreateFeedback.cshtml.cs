using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Feedbacks
{ 
    public class CreateFeedbackModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public CreateFeedbackModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Feedback.Add(Feedback);
            //

            // Once a record is added, create an audit record
            if (await _context.SaveChangesAsync() > 0)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Add New Feedback Record";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyBookFieldID = Feedback.feedbackId;
                // Get current logged-in user
                var userID = "";
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}