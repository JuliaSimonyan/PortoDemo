﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Porto.Data.Models
{
    public class ChatMessage
    {   
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string GroupName { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }


}
