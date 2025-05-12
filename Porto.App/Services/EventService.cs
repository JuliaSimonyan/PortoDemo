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
        public Task<bool> AddEvent(EventViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlace(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditEvent(EventViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<EventViewModel>> GetAllEvents()
        {
            throw new NotImplementedException();
        }

        //public async Task<List<EventViewModel>> GetAllEvents()
        //{
        //    List<EventViewModel> events = _context.Events.Select(
        //         v => new EventViewModel
        //         {
        //             Id = v.Id,
        //             Name = v.Name,
        //             StartDate = v.StartDate,
        //             EndDate = v.EndDate,
        //             Location = v.Location,
        //             Description = v.Description,
        //             Organizer = v.Organizer,
        //             ContactInfo = v.ContactInfo
        //         }

        //     ).ToList();
        //    return events;
        //}

        public Task<EventViewModel> GetEventById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
