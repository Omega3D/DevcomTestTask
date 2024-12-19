using Devcom.Application.Interfaces;
using Devcom.Domain.Entities;
using Devcom.Domain.Interfaces;
using Devcom.Domain.Params;

namespace Devcom.Application.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task AddAsync(AddAnnouncementParams announcement)
        {
            await _announcementRepository.AddAsync(announcement);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _announcementRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Announcement>> GetAllAsync()
        {
            return await _announcementRepository.GetAllAsync();
        }

        public async Task<Announcement?> GetByIdAsync(int id)
        {
            return await _announcementRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(UpdateAnnouncementParams announcement)
        {
            return await _announcementRepository.UpdateAsync(announcement);
        }
    }
}
