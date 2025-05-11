using Porto.Common.ViewModel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Porto.App.Interfaces
{
    public interface IEvent
    {
        Task<List<EventViewModel>> GetAllEvents();
        Task<EventViewModel> GetEventById(int id);
        Task<bool> AddEvent(EventViewModel model);
        Task<bool> EditEvent(EventViewModel model);
        Task<bool> DeletePlace(int id);
    }
}
