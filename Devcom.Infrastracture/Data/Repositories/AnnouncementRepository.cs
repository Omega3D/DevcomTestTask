using Devcom.Domain.Entities;
using Devcom.Domain.Interfaces;
using Devcom.Domain.Params;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Devcom.Infrastracture.Data.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly ApplicationDbContext _context;
        public AnnouncementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AddAnnouncementParams announcement)
        {
            var parameters = new[]
            {
                new SqlParameter("@Title", announcement.Title),
                new SqlParameter("@Description", announcement.Description),
                new SqlParameter("@Status", announcement.Status.ToString()),
                new SqlParameter("@Category", announcement.Category),
                new SqlParameter("@SubCategory", announcement.SubCategory)
            };

            await _context.Database.ExecuteSqlRawAsync(
            "EXEC spCreateAnnouncement @Title, @Description, @Status, @Category, @SubCategory",
            parameters);
        }

        public async Task<int> DeleteAsync(int id)
        {
            var param = new SqlParameter("@Id", id);

            return await _context.Database.ExecuteSqlRawAsync(
            "EXEC spDeleteAnnouncement @Id",
            param);
        }

        public async Task<IEnumerable<Announcement>> GetAllAsync()
        {
            var annEntity = await _context.Announcements.FromSqlRaw("spGetAllAnnouncements").ToListAsync();

            var ann = annEntity.Select(a => Announcement.Create(
                a.Id,
                a.Title,
                a.Description,
                a.CreatedDate,
                a.Status,
                a.Category,
                a.SubCategory).Announcement).ToList();

            return ann;
        }

        public async Task<Announcement?> GetByIdAsync(int id)
        {
            var param = new SqlParameter("@Id", id);

            var annEntity = await _context.Announcements
                .FromSqlRaw("EXEC spGetAnnouncementById @Id", param)
                .ToListAsync();

            var ann = annEntity.Select(a => Announcement.Create(
                a.Id,
                a.Title,
                a.Description,
                a.CreatedDate,
                a.Status,
                a.Category,
                a.SubCategory).Announcement);

            return ann.FirstOrDefault();
        }


        public async Task<int> UpdateAsync(UpdateAnnouncementParams announcement)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", announcement.Id),
                new SqlParameter("@Title", announcement.Title),
                new SqlParameter("@Description", announcement.Description),
                new SqlParameter("@Status", announcement.Status.ToString()),
                new SqlParameter("@Category", announcement.Category),
                new SqlParameter("@SubCategory", announcement.SubCategory)
            };

            return await _context.Database.ExecuteSqlRawAsync(
            "EXEC spUpdateAnnouncement @Id, @Title, @Description, @Status, @Category, @SubCategory",
            parameters);
        }
    }
}
