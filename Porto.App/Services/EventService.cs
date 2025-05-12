using Porto.App.Interfaces;
using Porto.Common.ViewModel.Events;
using Microsoft.EntityFrameworkCore;
using Porto.Data.Models;    

namespace Porto.App.Services
{
    public class EventService : IEvent
    {
        private readonly ApplicationContext _context;

        public EventService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<bool> AddEvent(EventViewModel model)
        {
            if (_context.Events.Select(i => i.Name).Contains(model.Name) || model == null) return false;
            Event newevent = new Event
            {
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Location = model.Location,
                Description = model.Description,
                Organizer = model.Organizer,
                ContactInfo = model.ContactInfo,

            };
            await _context.Events.AddAsync(newevent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePlace(int id)
        {
            var newEvent = await _context.Events.FindAsync(id); 
            if (newEvent == null) return false;

            _context.Events.Remove(newEvent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditEvent(EventViewModel model)
        {
            var newEvent = await _context.Events.FirstOrDefaultAsync(p => p.Id == model.Id);
            if (newEvent == null) return false;

            newEvent.Name = model.Name;
            newEvent.StartDate = model.StartDate;
            newEvent.EndDate = model.EndDate;
            newEvent.Location = model.Location;
            newEvent.Description = model.Description;
            newEvent.Organizer = model.Organizer;
            newEvent.ContactInfo = model.ContactInfo;
           
            _context.Events.Update(newEvent);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EventViewModel>> GetAllEvents()
        {
            List<EventViewModel> events = _context.Events.Select(
                 v => new EventViewModel
                 {
                     Id = v.Id,
                     Name = v.Name,
                     StartDate = v.StartDate,
                     EndDate = v.EndDate,
                     Location = v.Location,
                     Description = v.Description,
                     Organizer = v.Organizer,
                     ContactInfo = v.ContactInfo
                 }

             ).ToList();
            return events;
        }

        public async Task<EventViewModel> GetEventById(int id)
        {
            var evennt = await _context.Events.FirstOrDefaultAsync(p => p.Id == id);
            if (evennt == null) return null;

            return new EventViewModel
            {
                Id = evennt.Id,
                Name = evennt.Name,
                StartDate = evennt.StartDate,
                EndDate = evennt.EndDate,
                Location = evennt.Location,
                Description = evennt.Description,
                Organizer = evennt.Organizer,
                ContactInfo = evennt.ContactInfo
            };
        }
    }
}
