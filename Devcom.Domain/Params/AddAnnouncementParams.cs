using Devcom.Domain.Enums;

namespace Devcom.Domain.Params
{
    public class AddAnnouncementParams
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.active;
        public string Category { get; set; } = string.Empty;
        public string SubCategory { get; set; } = string.Empty;
    }
}
