using Devcom.Domain.Enums;

namespace Devcom.Api.Models
{
    public record AnnouncementRequest(
    string Title,
    string Description,
    DateTime CreatedDate,
    Status Status,
    string Category,
    string SubCategory);
}
