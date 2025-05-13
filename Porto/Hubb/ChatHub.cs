using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Porto.Data;
using Porto.Data.Models;

namespace Porto.Hubb
{
    public class ChatHub : Hub
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatHub(ApplicationContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SendMessage(string message, string groupName)
        {
            // Get user from the current connection context
            var user = await _userManager.GetUserAsync(Context.User);
            if (user == null)
            {
                throw new HubException("User is not authenticated.");
            }

            var chatMessage = new ChatMessage
            {
                UserId = user.Id,
                UserName = user.UserName,
                GroupName = groupName,
                Message = message,
                Timestamp = DateTime.Now
            };

            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();

            await Clients.Group(groupName).SendAsync(
                "ReceiveMessage",
                user.UserName,
                message,
                chatMessage.Timestamp.ToString("g")
            );
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task<List<object>> GetGroupMessages(string groupName)
        {
            return await _context.ChatMessages
                .Where(m => m.GroupName == groupName)
                .OrderBy(m => m.Timestamp)
                .Select(m => new
                {
                    userName = m.User.UserName,
                    message = m.Message,
                    timestamp = m.Timestamp.ToString("g")
                })
                .ToListAsync<object>();
        }
    }
}
