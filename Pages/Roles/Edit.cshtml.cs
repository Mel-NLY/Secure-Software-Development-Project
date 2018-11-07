using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SSDAssignmentBOX.Models;
using Microsoft.AspNetCore.Authorization;

namespace SSDAssignmentBOX.Pages.Roles
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public EditModel(SSDAssignmentBOX.Models.BookContext context, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationRole = await _roleManager.FindByIdAsync(id);
            if (ApplicationRole == null)
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
            ApplicationRole appRole = await _roleManager.FindByIdAsync(ApplicationRole.Id);
            appRole.Id = ApplicationRole.Id;
            appRole.Name = ApplicationRole.Name;
            appRole.Description = ApplicationRole.Description;

            IdentityResult roleRuslt = await _roleManager.UpdateAsync(appRole); //When the form is posted with the data, the UpdateAsync method of the roleManager class which has existing ApplicationRole as a parameter will update the role in the application.

            if (roleRuslt.Succeeded)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Edited " + ApplicationRole + " Role";
                auditrecord.DateTimeStamp = System.DateTime.Now;
                auditrecord.KeyBookFieldID = 777;
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return RedirectToPage("./Index");
        }
    }
}