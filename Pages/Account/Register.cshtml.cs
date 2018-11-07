using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SSDAssignmentBOX.Models;

namespace SSDAssignmentBOX.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager; //UserManager class is creating and managing users
        public RegisterModel(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [BindProperty]
        public InputModel Input { get; set; } //InputModel is view model that hold the data entered on the register view.
        public string ReturnUrl { get; set; }
        public class InputModel
        {
            [Required(ErrorMessage = "The email address is required")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required(ErrorMessage = "A password is required")]
            [StringLength(100, ErrorMessage = "The {0} must be at least 12 characters", MinimumLength = 12)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Display(Name = "Full Name")]
            public string FullName { get; set; }
            [DataType(DataType.Date)]
            [Display(Name = "BirthDate")]
            public DateTime BirthDate{ get; set; }


            //[Required(ErrorMessage = "Please Enter Your StudentID")]
            [RegularExpression("^(s|t)[0-9]{8}[a-jz]{1}$", ErrorMessage = "Please Enter a valid StudentID eg.S12345678X")]
            [Display(Name = "StudentID ")]
            public string StudentID { get; set; }

            //[Required]
            [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Please Enter your School (e.g Ngee Ann Polytechnic) ")]
            [Display(Name = "School's Name")]
            public string SchoolName { get; set; }
        }
        public void OnGet(string returnUrl = null)
        { ReturnUrl = returnUrl; }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, FullName = Input.FullName, BirthDate = Input.BirthDate, StudentID = Input.StudentID, SchoolName = Input.SchoolName };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(Url.GetLocalUrl(returnUrl));
                }
                foreach (var error in result.Errors)
                { ModelState.AddModelError(string.Empty, error.Description); }
            }
            return Page();
        }
    }
}