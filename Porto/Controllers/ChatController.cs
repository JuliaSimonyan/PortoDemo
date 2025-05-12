using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Porto.Data;
using Porto.Data.Models;
    
namespace Porto.Controllers
{
    public class ChatController : Controller
    {
        private readonly ApplicationContext _context;

        public ChatController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var messages = await _context.ChatMessages
                .Include(m => m.User)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();

            return View(messages);
        }
    }
}
