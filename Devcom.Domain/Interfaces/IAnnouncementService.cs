using Devcom.Domain.Entities;
using Devcom.Domain.Params;

namespace Devcom.Application.Interfaces
{
    public interface IAnnouncementService
    {
        Task AddAsync(AddAnnouncementParams announcement);
        Task<Announcement?> GetByIdAsync(int id);
        Task<IEnumerable<Announcement>> GetAllAsync();
        Task<int> UpdateAsync(UpdateAnnouncementParams announcement);
        Task<int> DeleteAsync(int id);
    }
}
