using Microsoft.AspNetCore.Identity;

namespace Porto.DLL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ChatMessage> Messages { get; set; }


    }

}
