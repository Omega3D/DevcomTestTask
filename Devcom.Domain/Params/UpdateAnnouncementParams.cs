
using Devcom.Domain.Enums;

namespace Devcom.Domain.Params
{
    public class UpdateAnnouncementParams
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.active;
        public string Category { get; set; } = string.Empty;
        public string SubCategory { get; set; } = string.Empty;
    }
}
