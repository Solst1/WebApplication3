using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication3.Model;

namespace WebApplication3.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public ApplicationUser currentUser { get; set; }

        private UserManager<IdentityUser> _userManager { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            var Email = HttpContext.Session.GetString("Email");

            currentUser = (ApplicationUser)_userManager.Users.FirstOrDefault(u => u.Email == Email);

            return Page();
        }
    }
}