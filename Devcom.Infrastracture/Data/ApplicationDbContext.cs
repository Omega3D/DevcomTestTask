using Devcom.Infrastracture.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devcom.Infrastracture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnnouncementEntity>()
                .Property(a => a.Status)
                .HasConversion<string>();

            modelBuilder.Entity<AnnouncementEntity>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        }

        public DbSet<AnnouncementEntity> Announcements { get; set; }
    }
}
