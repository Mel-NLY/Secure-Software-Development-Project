using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SSDAssignmentBOX.Models;
using Microsoft.AspNetCore.Authorization;

namespace SSDAssignmentBOX.Pages.Libraries
{
    [Authorize(Roles = "Admin, Staff")]
    public class EditModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;

        public EditModel(SSDAssignmentBOX.Models.BookContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Library).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();

                // Once a record is edited, create an audit record
                if (await _context.SaveChangesAsync() > 0)
                {
                    // Create an auditrecord object
                    var auditrecord = new AuditRecord();
                    auditrecord.AuditActionType = "Edit Library Record";
                    auditrecord.DateTimeStamp = DateTime.Now;
                    auditrecord.KeyBookFieldID = Library.Id;
                    // Get current logged-in user
                    var userID = User.Identity.Name.ToString();
                    auditrecord.Username = userID;
                    _context.AuditRecords.Add(auditrecord);
                    await _context.SaveChangesAsync();
                }


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(Library.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LibraryExists(int id)
        {
            return _context.Library.Any(e => e.Id == id);
        }
    }
}
