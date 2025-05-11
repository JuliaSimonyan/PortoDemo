
namespace Porto.DLL.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Organizer { get; set; }
        public string ContactInfo { get; set; }
    }
}
