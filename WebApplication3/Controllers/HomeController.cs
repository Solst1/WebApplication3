using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.Controllers
{
	public class HomeController : Controller
	{
        private readonly IHttpContextAccessor contxt;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            contxt = httpContextAccessor;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(IFormCollection fc)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}

