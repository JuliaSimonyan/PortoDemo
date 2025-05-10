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

            // Պահել լեզուն cookie-ում
            Response.Cookies.Append(CultureCookieName, lang, new Microsoft.AspNetCore.Http.CookieOptions
            {

                Expires = DateTime.UtcNow.AddYears(1),  // Լեզուն պահպանվում է 1 տարի
                IsEssential = true, // Անհրաժեշտ է կարգավորումների համար
                SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax // Համակարգչի միջավայրում
            });

            // Արտահանենք լեզվով փոխված էջը
            return RedirectToAction("Index");
        }
    }
}
