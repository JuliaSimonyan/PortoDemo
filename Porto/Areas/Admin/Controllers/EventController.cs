using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Porto.App.Interfaces;
using Porto.Common.ViewModel.Events;

namespace Porto.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly IEvent _eventService;

        public EventController(IEvent eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllEvents();
            return View(events);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(EventViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = await _eventService.AddEvent(model);
            if (!success)
            {
                ModelState.AddModelError("", "Event already exists or is invalid.");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var eventVm = await _eventService.GetEventById(id);
            if (eventVm == null)
                return NotFound();

            return View(eventVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var success = await _eventService.EditEvent(model);
            if (!success)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _eventService.DeletePlace(id);
            if (!success)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }


    }
}
