using Devcom.Domain.Enums;

namespace Devcom.Api.Models
{
    public record AnnouncementDto(
    int Id,
    string Title,
    string Description,
    DateTime CreatedDate,
    Status Status,
    string Category,
    string SubCategory);
}
