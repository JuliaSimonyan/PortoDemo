using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Porto.Models;

namespace Porto.Controllers
{
    public class HomeController : Controller
    {
        private const string CultureCookieName = "UserCulture";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Live()
        {
            return View();
        }

        public IActionResult Work()
        {
            return View();
        }

        public IActionResult Integrate()
        {
            return View();
        }


        public IActionResult ChangeLanguage(string lang)
        {
            Response.Cookies.Append(CultureCookieName, lang, new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.UtcNow.AddYears(1),
                IsEssential = true,
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax
            });

            return RedirectToAction("Index");
        }
    }
}
