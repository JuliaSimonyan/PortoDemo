using Microsoft.AspNetCore.Mvc;

namespace Porto.Controllers
{
    public class StaticChatBotController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
