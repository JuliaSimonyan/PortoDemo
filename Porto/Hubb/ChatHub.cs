using Microsoft.AspNetCore.SignalR;
using Porto.Data;
using Porto.Data.Models;


namespace Porto.Hubb
{
    public class ChatHub : Hub
    {
        private readonly ApplicationContext _context;

        public ChatHub(ApplicationContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string userId, string message)
        {
            var user = await _context.Users.FindAsync(userId);

            var chatMessage = new ChatMessage
            {
                UserId = userId,
                UserName = Context.User.Identity.Name,
                Message = message,
                Timestamp = DateTime.Now
            };

            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("ReceiveMessage", user.UserName, message);


        }
    }
}
