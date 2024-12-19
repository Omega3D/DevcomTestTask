using Devcom.Domain.Entities;
using Devcom.Domain.Params;

namespace Devcom.Domain.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task AddAsync(AddAnnouncementParams announcement);
        Task<Announcement?> GetByIdAsync(int id);
        Task<IEnumerable<Announcement>> GetAllAsync();
        Task<int> UpdateAsync(UpdateAnnouncementParams announcement);
        Task<int> DeleteAsync(int id);
    }
}
