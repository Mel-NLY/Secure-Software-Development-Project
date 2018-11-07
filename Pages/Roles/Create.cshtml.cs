using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SSDAssignmentBOX.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SSDAssignmentBOX.Pages.Roles
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly SSDAssignmentBOX.Models.BookContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public CreateModel(SSDAssignmentBOX.Models.BookContext context, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ApplicationRole.CreatedDate = DateTime.UtcNow;
            ApplicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            //This class takes RoleManager as constructor parameter. ASP.NET Core Dependency Injection will take care of passing the instance of RoleManager into this razor page.
            IdentityResult roleRuslt = await _roleManager.CreateAsync(ApplicationRole); //This method has new ApplicationRole as a parameter and creates new role in the application.This will also return true or false on the whether the creation of new role is successful.

            // Create an auditrecord object
            var auditrecord = new AuditRecord();
            auditrecord.AuditActionType = "Created new Role," + ApplicationRole;
            auditrecord.DateTimeStamp = DateTime.Now;
            auditrecord.KeyBookFieldID = 777;
            // Get current logged-in user
            var userID = User.Identity.Name.ToString();
            auditrecord.Username = userID;
            _context.AuditRecords.Add(auditrecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}