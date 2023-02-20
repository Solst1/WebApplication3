using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Model;
using WebApplication3.ViewModels;

namespace WebApplication3.Pages
{
    public class RegisterModel : PageModel
    {

        private UserManager<IdentityUser> userManager { get; }
        private SignInManager<IdentityUser> signInManager { get; }

        [BindProperty]
        public Register RModel { get; set; }

        [BindProperty]
        public string Gender { get; set; }
        public string[] Genders = new[] { "Male", "Female" };

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
        ) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                //XSS Prevention
                RModel.fName = HttpUtility.HtmlEncode(RModel.fName);
                RModel.lName = HttpUtility.HtmlEncode(RModel.lName);
                RModel.Gender = Gender;
                RModel.NRIC = HttpUtility.HtmlEncode(RModel.NRIC);
                RModel.Email = HttpUtility.HtmlEncode(RModel.Email);
                RModel.Password = HttpUtility.HtmlEncode(RModel.Password);
                RModel.ResumeName = HttpUtility.HtmlEncode(RModel.Resume.FileName);
                RModel.whoami = HttpUtility.HtmlEncode(RModel.whoami);

                var user = new ApplicationUser()
                {
                    UserName = RModel.Email,
                    Email = RModel.Email
                };
                var result = await userManager.CreateAsync(user, RModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }


    }
}
