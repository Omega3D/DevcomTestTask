using Devcom.Domain.Enums;

namespace Devcom.Infrastracture.Data.Entities
{
    public class AnnouncementEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.active;
        public string Category { get; set; } = string.Empty;
        public string SubCategory { get; set; } = string.Empty;
    }
}
