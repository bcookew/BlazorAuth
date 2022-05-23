using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlazorAuth.Areas.Identity.Data;

namespace BlazorAuth.Areas.Identity.Pages.PageModels
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RegisterModel(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");
            if(ModelState.IsValid)
            {
                var user = new User { 
                    FirstName = Input.FirstName, 
                    LastName = Input.LastName,
                    DOB = Input.DOB, 
                    UserName = Input.Email, 
                    Email = Input.Email};
                var result = await _userManager.CreateAsync(user, Input.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(ReturnUrl);
                }
            }
            return Page();
        }
        public class InputModel
        {
            [Required]
            [MinLength(2, ErrorMessage ="Minimum 2 Characters")]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }
            
            [Required]
            [MinLength(2, ErrorMessage ="Minimum 2 Characters")]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
            
            [Required]
            [Display(Name = "Birthdate")]
            [DataType(DataType.Date)]
            public DateTime DOB { get; set; }
            
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [Display(Name = "Confirm Password")]
            [DataType(DataType.Password)]
            [Compare("Password")]
            public string ConfirmPassword { get; set; }
        }
    }
}